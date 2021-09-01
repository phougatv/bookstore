namespace Atlantis.Books.Abstractions
{
    using System;

    /// <summary>
    /// Generic <see cref="IRepository{TEntity}"/>.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        internal bool Create(TEntity entity);
        internal TEntity Read(Guid id);
        internal bool Update(TEntity book);
        internal bool Delete(Guid id);
    }
}
