namespace WebAPI.Books.Controllers
{
    using Atlantis.Books;
    using Microsoft.AspNetCore.Mvc;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;

        public BooksController(BookService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            var isCreated = _service.Created(book);

            return StatusCode(Status201Created, isCreated);
        }
    }
}
