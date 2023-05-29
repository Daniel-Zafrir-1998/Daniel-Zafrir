using MediatR;
using AutoMapper;

public class GetGenreHandler : IRequestHandler<GetGenreQuery, GenreResponseModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;
    public GetGenreHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    public async Task<GenreResponseModel> Handle(GetGenreQuery request, CancellationToken cancellationToken)
    {
        var Genre = await _context.Genres.FindAsync(request.GenreID);
        var toReturn = _mapper.Map<GenreResponseModel>(Genre);

        return toReturn;
    }
}