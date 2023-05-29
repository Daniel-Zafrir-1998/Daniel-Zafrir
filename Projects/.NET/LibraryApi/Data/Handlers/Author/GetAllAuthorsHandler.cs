using MediatR;
using AutoMapper;
public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorResponseModel>>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;
    public GetAllAuthorsHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<AuthorResponseModel>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var response = _context.Authors
                               .Select(x => _mapper.Map<Author, AuthorResponseModel>(x))
                               .ToList();

        await Task.CompletedTask;

        return response;
    }
}