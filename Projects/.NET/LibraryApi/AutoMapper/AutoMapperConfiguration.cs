using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Book, BookResponseModel>();
        CreateMap<Book, BookRequestModel>();
    }
}