namespace WebAPI.Books.Controllers
{
    using Atlantis.Books;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;

        public BooksController(BookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Isbn = "13-digit-number",
                Title = "Book Test 1",
                Year = 2021
            };
            _service.Created(book);

            return Ok();
        }
    }
}
