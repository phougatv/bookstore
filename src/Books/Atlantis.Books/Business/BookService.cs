namespace Atlantis.Books.Business
{
    using Atlantis.Books.Dtos;
    using Atlantis.Books.Persistence;
    using Atlantis.Books.Persistence.Pocos;
    using AutoMapper;
    using System;

    /// <summary>
    /// BookService class.
    /// </summary>
    class BookService : IBookService
    {
        private readonly AtlantisDbContext _dbContext;
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates an instance of <see cref="BookService"/>.
        /// </summary>
        /// <param name="dbContext">The db context <see cref="AtlantisDbContext"/>.</param>
        /// <param name="repository">The repository <see cref="BookRepository"/>.</param>
        public BookService(
            AtlantisDbContext dbContext,
            IBookRepository repository,
            IMapper mapper)
        {
            _dbContext = dbContext;
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
            var book = _mapper.Map<Book>(bookDto);
            var isStateAdded = _repository.Create(book);
            var affectedRows = _dbContext.SaveChanges();

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
            var dto = _mapper.Map<BookDto>(book);

            return dto;
        }

        /// <summary>
        /// Updates book.
        /// </summary>
        /// <param name="bookDto">The book dto <see cref="BookDto"/>.</param>
        /// <returns></returns>
        public bool Update(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var isStateUpdated = _repository.Update(book);
            var affectedRows = _dbContext.SaveChanges();

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
            var affectedRows = _dbContext.SaveChanges();

            return isStateDeleted && affectedRows == 1;
        }
    }
}
