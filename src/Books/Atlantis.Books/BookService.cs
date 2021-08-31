namespace Atlantis.Books
{
    /// <summary>
    /// BookService class.
    /// </summary>
    public class BookService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly BookRepository _repository;

        /// <summary>
        /// Creates an instance of <see cref="BookService"/>.
        /// </summary>
        /// <param name="dbContext">The db context <see cref="ApplicationDbContext"/>.</param>
        /// <param name="repository">The repository <see cref="BookRepository"/>.</param>
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
