namespace Atlantis.Books.Persistence.Base
{
    using Atlantis.Books.Shared.Extensions;
    using System;

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
            entity.CreatedOn = DateTime.UtcNow;
            var entityEntry = _dbContext.Set<TEntity>().Add(entity);
            return entityEntry.IsAdded();
        }

        TEntity IRepository<TEntity, TId>.Read(TId id) => InternalReadById(id);

        bool IRepository<TEntity, TId>.Update(TEntity entity)
        {
            var internalEntity = InternalReadById(entity.Id);
            entity.CreatedOn = internalEntity.CreatedOn;
            entity.UpdatedOn = DateTime.UtcNow;
            _dbContext.Entry(internalEntity).Detach();

            var entityEntry = _dbContext.Attach(entity);
            entityEntry.Modify();

            return entityEntry.IsModified();
        }

        bool IRepository<TEntity, TId>.Delete(TId id)
        {
            var entity = InternalReadById(id);
            if (entity == null)
                return false;

            var entityEntry = _dbContext.Set<TEntity>().Remove(entity);
            return entityEntry.IsDeleted();
        }
        #endregion Public Methods

        #region Protected Abstract Methods
        protected virtual TEntity InternalReadById(TId id) => _dbContext.Set<TEntity>().Find(id);
        #endregion Protected Abstract Methods
    }
}
