namespace Atlantis.Books.Persistence
{
    /// <summary>
    /// IUnitOfWork interface.
    /// </summary>
    interface IUnitOfWork
    {
        /// <summary>
        /// Commits all the DB changes.
        /// </summary>
        /// <returns></returns>
        int Commit();
    }
}
