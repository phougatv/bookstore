namespace WebAPI.Books.Controllers
{
    using Atlantis.Books;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    /// <summary>
    /// BooksController class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;

        /// <summary>
        /// Ctor creates an instance of <see cref="BooksController"/>.
        /// </summary>
        /// <param name="service">The service <see cref="BookService"/>.</param>
        public BooksController(BookService service)
        {
            _service = service;
        }

        /// <summary>
        /// Creates <see cref="Book"/>.
        /// </summary>
        /// <param name="book">The book <see cref="Book"/>.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Book book)
        {
            var isCreated = _service.Create(book);

            return StatusCode(Status201Created, isCreated);
        }

        /// <summary>
        /// Gets <see cref="Book"/> based on the id.
        /// </summary>
        /// <param name="id">The id <see cref="Guid"/>.</param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public IActionResult Read(Guid id)
        {
            var book = _service.Read(id);

            return Ok(book);
        }

        /// <summary>
        /// Updates the book based on id <see cref="Guid"/>.
        /// </summary>
        /// <param name="book">The book <see cref="Book"/>.</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(Book book)
        {
            var isUpdated = _service.Update(book);
            var message = isUpdated ? "Record updated successfully" : "Failed to update";

            return Ok(message);
        }

        /// <summary>
        /// Deletes the <see cref="Book"/> based on the id.
        /// </summary>
        /// <param name="id">The id <see cref="Guid"/>.</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var isDeleted = _service.Delete(id);
            var message = isDeleted ? "Record deleted successfully" : "Failed to delete";

            return Ok(message);
        }
    }
}
