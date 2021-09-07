namespace Atlantis.Books.Business
{
    using Atlantis.Books.Dtos;
    using System;

    /// <summary>
    /// IBookService interface.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="bookDto">The book dto <see cref="BookDto"/>.</param>
        /// <returns></returns>
        bool Create(BookDto bookDto);
        BookDto Read(Guid id);
        bool Update(BookDto bookDto);
        bool Delete(Guid id);
    }
}
