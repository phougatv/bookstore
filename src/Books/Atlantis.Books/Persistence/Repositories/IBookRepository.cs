namespace Atlantis.Books.Persistence.Repositories
{
    using Atlantis.Books.Persistence.Base;
    using Atlantis.Books.Persistence.Pocos;
    using System;

    /// <summary>
    /// IBookRepository interface.
    /// </summary>
    public interface IBookRepository : IRepository<Book, Guid>
    {

    }
}
