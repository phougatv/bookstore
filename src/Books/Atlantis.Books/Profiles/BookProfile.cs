namespace Atlantis.Books.Profiles
{
    using Atlantis.Books.Dtos;
    using Atlantis.Books.Persistence.Pocos;
    using AutoMapper;

    /// <summary>
    /// BookProfile class.
    /// </summary>
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
