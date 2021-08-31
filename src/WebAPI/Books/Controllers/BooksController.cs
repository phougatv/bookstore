namespace WebAPI.Books.Controllers
{
    using Atlantis.Books;
    using Microsoft.AspNetCore.Mvc;
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
        /// Creates a record of <see cref="Book"/>.
        /// </summary>
        /// <param name="book">The book <see cref="Book"/>.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Book book)
        {
            var isCreated = _service.Created(book);

            return StatusCode(Status201Created, isCreated);
        }
    }
}
