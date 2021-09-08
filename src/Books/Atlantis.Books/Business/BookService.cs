namespace Atlantis.Books.Business
{
    using Atlantis.Books.Business.DomainModels;
    using Atlantis.Books.Dtos;
    using Atlantis.Books.Persistence;
    using Atlantis.Books.Persistence.Pocos;
    using Atlantis.Books.Persistence.Repositories;
    using AutoMapper;
    using System;

    /// <summary>
    /// BookService class.
    /// </summary>
    class BookService : IBookService
    {
        private readonly IUnitOfWork _uow;
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates an instance of <see cref="BookService"/>.
        /// </summary>
        /// <param name="dbContext">The db context <see cref="AtlantisDbContext"/>.</param>
        /// <param name="repository">The repository <see cref="BookRepository"/>.</param>
        public BookService(
            IUnitOfWork uow,
            IBookRepository repository,
            IMapper mapper)
        {
            _uow = uow;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="bookDto">The book dto <see cref="BookDto"/>.</param>
        /// <returns></returns>
        public bool Create(BookDto bookDto)
        {
            var bookDomain = _mapper.Map<BookDomain>(bookDto);
            var book = _mapper.Map<Book>(bookDomain);
            var isStateAdded = _repository.Create(book);
            var affectedRows = _uow.Commit();

            return isStateAdded && affectedRows == 1;   // Only 1 row should be created in single scope.
        }

        /// <summary>
        /// Reads a <see cref="BookModel"/> based on the id.
        /// </summary>
        /// <param name="id">The id <see cref="Guid"/>.</param>
        /// <returns></returns>
        public BookDto Read(Guid id)
        {
            var book = _repository.Read(id);
            var bookDomain = _mapper.Map<BookDomain>(book);
            var bookDto = _mapper.Map<BookDto>(bookDomain);

            return bookDto;
        }

        /// <summary>
        /// Updates book.
        /// </summary>
        /// <param name="bookDto">The book dto <see cref="BookDto"/>.</param>
        /// <returns></returns>
        public bool Update(BookDto bookDto)
        {
            var bookDomain = _mapper.Map<BookDomain>(bookDto);
            var book = _mapper.Map<Book>(bookDomain);
            var isStateUpdated = _repository.Update(book);
            var affectedRows = _uow.Commit();

            return isStateUpdated && affectedRows == 1;
        }

        /// <summary>
        /// Deletes the record.
        /// </summary>
        /// <param name="id">The id <see cref="Guid"/>.</param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            var isStateDeleted = _repository.Delete(id);
            var affectedRows = _uow.Commit();

            return isStateDeleted && affectedRows == 1;
        }
    }
}
