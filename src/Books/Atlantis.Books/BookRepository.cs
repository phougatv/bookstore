namespace Atlantis.Books
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    /// <summary>
    /// BookRepository class.
    /// </summary>
    public class BookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Creates an instance of <see cref="BookRepository"/>.
        /// </summary>
        /// <param name="dbContext">The db context <see cref="ApplicationDbContext"/>.</param>
        public BookRepository(ApplicationDbContext dbContext)
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
        internal bool Create(Book book)
        {
            var entityEntry = _dbContext.Books.Add(book);
            return entityEntry.State == EntityState.Added;
        }

        /// <summary>
        /// Returns an null or instance of <see cref="Book"/>, if id (<see cref="Guid"/>) exists.
        /// </summary>
        /// <param name="id">The id <see cref="Guid"/>.</param>
        /// <returns></returns>
        internal Book Read(Guid id) => InternalReadById(id);

        /// <summary>
        /// Updates book based on the id (<see cref="Guid"/>).
        /// </summary>
        /// <param name="book">The book <see cref="Book"/>.</param>
        /// <returns></returns>
        internal bool Update(Book book)
        {
            var entityEntry = _dbContext.Attach(book);
            entityEntry.State = EntityState.Modified;

            return entityEntry.State == EntityState.Modified;
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
