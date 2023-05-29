using MediatR;
using AutoMapper;

public class AddGenreHandler : IRequestHandler<AddGenreCommand, GenreRequestModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;

    public AddGenreHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenreRequestModel> Handle(AddGenreCommand request, CancellationToken cancellationToken)
    {
        var Genre = _mapper.Map<Genre>(request.GenreRequest);

        await _context.AddAsync(Genre);
        await _context.SaveChangesAsync();

        return request.GenreRequest;
    }
}