namespace Atlantis.Books.Persistence.Repositories
{
    using Atlantis.Books.Persistence.Base;
    using Atlantis.Books.Persistence.Pocos;
    using System;

    /// <summary>
    /// BookRepository class.
    /// </summary>
    internal class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        private readonly AtlantisDbContext _dbContext;

        public BookRepository(AtlantisDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        protected override Book InternalReadById(Guid id) => _dbContext.Set<Book>().Find(id);
    }
}
