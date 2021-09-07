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
        bool Create(TEntity entity);
        TEntity Read(TId id);
        bool Update(TEntity book);
        bool Delete(TId id);
    }
}
