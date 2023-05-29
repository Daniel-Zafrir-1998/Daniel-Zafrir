using MediatR;
using AutoMapper;

public class UpdateGenreHandler : IRequestHandler<UpdateGenreCommand, GenreRequestModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;

    public UpdateGenreHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenreRequestModel> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var Genre = _context.Genres.Where(x => x.ID == request.GenreRequest.ID).First();

        _mapper.Map(request.GenreRequest, Genre);

        await _context.SaveChangesAsync();

        return request.GenreRequest;
    }
}