namespace Atlantis.Books.Persistence.Base
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly AtlantisDbContext _dbContext;

        /// <summary>
        /// Ctor, creates an instance of repository.
        /// </summary>
        /// <param name="dbContext">The db context <see cref="AtlantisDbContext"/>.</param>
        protected Repository(AtlantisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Public Methods
        public bool Create(TEntity entity)
        {
            var entityEntry = _dbContext.Set<TEntity>().Add(entity);
            return entityEntry.State == EntityState.Added;
        }

        public TEntity Read(TId id) => InternalReadById(id);

        public bool Update(TEntity entity)
        {
            var entityEntry = _dbContext.Attach(entity);
            entityEntry.State = EntityState.Modified;

            return entityEntry.State == EntityState.Modified;
        }

        public bool Delete(TId id)
        {
            var entity = InternalReadById(id);
            if (entity == null)
                return false;

            var entityEntry = _dbContext.Set<TEntity>().Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        #endregion Public Methods

        #region Abstract Protected Methods
        protected abstract TEntity InternalReadById(TId id);
        #endregion Abstract Protected Methods
    }
}
