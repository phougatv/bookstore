namespace Atlantis.Books
{
    public class BookService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly BookRepository _repository;

        public BookService(ApplicationDbContext dbContext, BookRepository repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }

        public bool Created(Book book)
        {
            var isStateAdded = _repository.Create(book);
            var stateEntries = _dbContext.SaveChanges();

            return isStateAdded && stateEntries == 1;   // Only 1 row should be created in single scope.
        }
    }
}
