namespace Atlantis.Books.Persistence.Base
{
    using System;

    /// <summary>
    /// Generic <see cref="IRepository{TEntity}"/>.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal interface IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        /// <summary>
        /// Creates an entity.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/>.</param>
        /// <returns></returns>
        bool Create(TEntity entity);

        /// <summary>
        /// Reads an <see cref="TEntity"/> based on id.
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        TEntity Read(TId id);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/>.</param>
        /// <returns></returns>
        bool Update(TEntity book);

        /// <summary>
        /// Deletes an <see cref="TEntity"/> based on id.
        /// </summary>
        /// <param name="id">The <typeparamref name="TId"/>.</param>
        /// <returns></returns>
        bool Delete(TId id);
    }
}
