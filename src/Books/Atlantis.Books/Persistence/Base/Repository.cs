namespace Atlantis.Books.Persistence.Base
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
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
        bool IRepository<TEntity, TId>.Create(TEntity entity)
        {
            var entityEntry = _dbContext.Set<TEntity>().Add(entity);
            return entityEntry.State == EntityState.Added;
        }

        TEntity IRepository<TEntity, TId>.Read(TId id) => InternalReadById(id);

        bool IRepository<TEntity, TId>.Update(TEntity entity)
        {
            var entityEntry = _dbContext.Attach(entity);
            entityEntry.State = EntityState.Modified;

            return entityEntry.State == EntityState.Modified;
        }

        bool IRepository<TEntity, TId>.Delete(TId id)
        {
            var entity = InternalReadById(id);
            if (entity == null)
                return false;

            var entityEntry = _dbContext.Set<TEntity>().Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        #endregion Public Methods

        #region Protected Abstract Methods
        protected virtual TEntity InternalReadById(TId id) => _dbContext.Set<TEntity>().Find(id);
        #endregion Protected Abstract Methods
    }
}
