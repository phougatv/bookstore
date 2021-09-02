namespace Atlantis.Books.Business
{
    using Atlantis.Books.Dtos;
    using System;

    /// <summary>
    /// IBookService interface.
    /// </summary>
    public interface IBookService
    {
        bool Create(BookDto book);
        BookDto Read(Guid id);
        bool Update(BookDto book);
        bool Delete(Guid id);
    }
}
