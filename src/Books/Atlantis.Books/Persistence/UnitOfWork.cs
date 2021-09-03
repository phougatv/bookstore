namespace Atlantis.Books.Persistence
{
    /// <summary>
    /// UnitOfWork class.
    /// </summary>
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AtlantisDbContext _dbContext;

        public UnitOfWork(AtlantisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Commits all the DB changes.
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            var affectedRows = _dbContext.SaveChanges();
            return affectedRows;
        }
    }
}
