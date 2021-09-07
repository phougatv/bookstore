namespace Atlantis.Books.Persistence
{
    /// <summary>
    /// IUnitOfWork interface.
    /// </summary>
    interface IUnitOfWork
    {
        /// <summary>
        /// Commits all the entity entry changes.
        /// </summary>
        /// <returns></returns>
        int Commit();
    }
}
