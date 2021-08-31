namespace Atlantis.Books
{
    using Microsoft.EntityFrameworkCore;

    public class BookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal bool Create(Book book)
        {
            var entityEntry = _dbContext.Books.Add(book);
            return entityEntry.State == EntityState.Added;
        }
    }
}
