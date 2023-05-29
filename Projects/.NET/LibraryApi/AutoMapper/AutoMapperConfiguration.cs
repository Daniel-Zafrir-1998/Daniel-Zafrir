using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Book, BookResponseModel>().ReverseMap();
        CreateMap<Book, BookRequestModel>().ReverseMap();

        CreateMap<Author, AuthorResponseModel>().ReverseMap();
        CreateMap<Author, AuthorRequestModel>().ReverseMap();

        CreateMap<Genre, GenreResponseModel>().ReverseMap();
        CreateMap<Genre, GenreRequestModel>().ReverseMap();

        CreateMap<Patron, PatronResponseModel>().ReverseMap();
        CreateMap<Patron, PatronRequestModel>().ReverseMap();
    }
}