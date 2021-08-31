namespace Atlantis.Books
{
    using Microsoft.EntityFrameworkCore;

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
    }
}
