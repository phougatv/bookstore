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
        /// <summary>
        /// Creates an entity.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/>.</param>
        /// <returns></returns>
        bool IRepository<TEntity, TId>.Create(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            var entityEntry = _dbContext.Set<TEntity>().Add(entity);
            return entityEntry.IsAdded();
        }

        /// <summary>
        /// Reads an <see cref="TEntity"/> based on id.
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        TEntity IRepository<TEntity, TId>.Read(TId id) => InternalReadWhenDeleteHardIsSet(id);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/>.</param>
        /// <returns></returns>
        bool IRepository<TEntity, TId>.Update(TEntity entity) => InternalUpdate(entity);

        /// <summary>
        /// Deletes an <see cref="TEntity"/> based on id.
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        bool IRepository<TEntity, TId>.Delete(TId id) => InternalDeleteHard(id);
        #endregion Public Methods

        #region Protected Abstract Methods
        /// <summary>
        /// Reads an <see cref="TEntity"/> based on the id.
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        protected virtual TEntity InternalReadById(TId id) => _dbContext.Set<TEntity>().Find(id);

        /// <summary>
        /// Read using this method when record is permanently deleted.
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        protected virtual TEntity InternalReadWhenDeleteHardIsSet(TId id)
        {
            var entity = InternalReadById(id);
            if (entity == null)
                return null;

            return entity;
        }

        /// <summary>
        /// Read using this method when record soft delete is used to mark the record deleted.
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        protected virtual TEntity InternalReadWhenDeleteSoftIsSet(TId id)
        {
            var entity = InternalReadById(id);
            if (entity == null || entity.IsDeleted)
                return null;

            return entity;
        }

        /// <summary>
        /// Updates an entity by maintaining the CreatedOn and IsDeleted values and setting UpdateOn to DateTime.UtcNow.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/>.</param>
        /// <returns></returns>
        protected virtual bool InternalUpdate(TEntity entity)
        {
            var internalEntity = InternalReadById(entity.Id);
            entity.CreatedOn = internalEntity.CreatedOn;
            entity.IsDeleted = internalEntity.IsDeleted;
            entity.UpdatedOn = DateTime.UtcNow;
            _dbContext.Entry(internalEntity).Detach();

            var entityEntry = _dbContext.Attach(entity);
            entityEntry.Modify();

            return entityEntry.IsModified();
        }

        /// <summary>
        /// Deletes an <see cref="TEntity"/> permanently, based on id.
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        protected virtual bool InternalDeleteHard(TId id)
        {
            var entity = InternalReadById(id);
            if (entity == null)
                return false;

            var entityEntry = _dbContext.Set<TEntity>().Remove(entity);
            return entityEntry.IsDeleted();
        }

        /// <summary>
        /// Sets IsDeleted to true and UpdatedOn to DateTime.UtcNow. 
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        protected virtual bool InternalDeleteSoft(TId id)
        {
            var entity = InternalReadById(id);
            if (entity == null)
                return false;

            entity.IsDeleted = true;
            entity.UpdatedOn = DateTime.UtcNow;
            _dbContext.Entry(entity).Detach();

            var entityEntry = _dbContext.Attach(entity);
            entityEntry.Modify();
            return entityEntry.IsModified();
        }
        #endregion Protected Abstract Methods
    }
}
