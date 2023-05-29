using MediatR;
using AutoMapper;
public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, List<GenreResponseModel>>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;
    public GetAllGenresHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<GenreResponseModel>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var response = _context.Genres
                               .Select(x => _mapper.Map<Genre, GenreResponseModel>(x))
                               .ToList();

        await Task.CompletedTask;

        return response;
    }
}