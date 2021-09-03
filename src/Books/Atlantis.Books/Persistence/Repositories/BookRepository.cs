namespace Atlantis.Books.Persistence.Repositories
{
    using Atlantis.Books.Persistence.Pocos;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    /// <summary>
    /// BookRepository class.
    /// </summary>
    class BookRepository : IBookRepository
    {
        private readonly AtlantisDbContext _dbContext;

        /// <summary>
        /// Creates an instance of <see cref="BookRepository"/>.
        /// </summary>
        /// <param name="dbContext">The db context <see cref="AtlantisDbContext"/>.</param>
        public BookRepository(AtlantisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Internal Methods
        /// <summary>
        /// Returns true on adding the book to the db set and setting the state of entity entry to added.
        /// SaveChanges is the one that actually performs the changes in the DB.
        /// </summary>
        /// <param name="book">The book <see cref="Book"/>.</param>
        /// <returns></returns>
        bool IRepository<Book>.Create(Book book)
        {
            var entityEntry = _dbContext.Books.Add(book);
            return entityEntry.State == EntityState.Added;
        }

        /// <summary>
        /// Returns an null or instance of <see cref="Book"/>, if id (<see cref="Guid"/>) exists.
        /// </summary>
        /// <param name="id">The id <see cref="Guid"/>.</param>
        /// <returns></returns>
        Book IRepository<Book>.Read(Guid id) => InternalReadById(id);

        /// <summary>
        /// Updates book based on the id (<see cref="Guid"/>).
        /// </summary>
        /// <param name="book">The book <see cref="Book"/>.</param>
        /// <returns></returns>
        bool IRepository<Book>.Update(Book book)
        {
            var entityEntry = _dbContext.Attach(book);
            entityEntry.State = EntityState.Modified;

            return entityEntry.State == EntityState.Modified;
        }

        /// <summary>
        /// Permanently deletes the record.
        /// </summary>
        /// <param name="id">The id <see cref="Guid"/>.</param>
        /// <returns></returns>
        bool IRepository<Book>.Delete(Guid id)
        {
            var book = InternalReadById(id);
            if (book == null)
                return false;

            var entityEntry = _dbContext.Books.Remove(book);
            return entityEntry.State == EntityState.Deleted;
        }
        #endregion Internal Methods

        #region Private Methods
        /// <summary>
        /// Retrieves the <see cref="Book"/> based on id (<see cref="Guid"/>).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Book InternalReadById(Guid id) => _dbContext.Books.FirstOrDefault(book => book.Id == id);
        #endregion Private Methods
    }
}
