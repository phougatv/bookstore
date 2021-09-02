namespace Atlantis.Books.Concretes
{
    using Atlantis.Books.Abstractions;
    using System;

    /// <summary>
    /// BookService class.
    /// </summary>
    class BookService : IBookService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IBookRepository _repository;

        /// <summary>
        /// Creates an instance of <see cref="BookService"/>.
        /// </summary>
        /// <param name="dbContext">The db context <see cref="ApplicationDbContext"/>.</param>
        /// <param name="repository">The repository <see cref="BookRepository"/>.</param>
        public BookService(ApplicationDbContext dbContext, IBookRepository repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }

        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="book">The book <see cref="Book"/>.</param>
        /// <returns></returns>
        public bool Create(Book book)
        {
            var isStateAdded = _repository.Create(book);
            var affectedRows = _dbContext.SaveChanges();

            return isStateAdded && affectedRows == 1;   // Only 1 row should be created in single scope.
        }

        /// <summary>
        /// Reads a <see cref="Book"/> based on the id.
        /// </summary>
        /// <param name="id">The id <see cref="Guid"/>.</param>
        /// <returns></returns>
        public Book Read(Guid id) => _repository.Read(id);

        /// <summary>
        /// Updates book.
        /// </summary>
        /// <param name="book">The book <see cref="Book"/>.</param>
        /// <returns></returns>
        public bool Update(Book book)
        {
            var isStateUpdated = _repository.Update(book);
            var affectedRows = _dbContext.SaveChanges();

            return isStateUpdated && affectedRows == 1;
        }

        /// <summary>
        /// Deletes the record.
        /// </summary>
        /// <param name="id">The id <see cref="Guid"/>.</param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            var isStateDeleted = _repository.Delete(id);
            var affectedRows = _dbContext.SaveChanges();

            return isStateDeleted && affectedRows == 1;
        }
    }
}
