namespace Atlantis.Books.Abstractions
{
    using System;

    /// <summary>
    /// IBookService interface.
    /// </summary>
    public interface IBookService
    {
        bool Create(Book book);
        Book Read(Guid id);
        bool Update(Book book);
        bool Delete(Guid id);
    }
}
