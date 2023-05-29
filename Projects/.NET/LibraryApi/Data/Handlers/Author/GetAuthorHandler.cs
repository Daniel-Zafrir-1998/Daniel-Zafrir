using MediatR;
using AutoMapper;

public class GetAuthorHandler : IRequestHandler<GetAuthorQuery, AuthorResponseModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;
    public GetAuthorHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    public async Task<AuthorResponseModel> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _context.Authors.FindAsync(request.AuthorID);
        var toReturn = _mapper.Map<AuthorResponseModel>(author);

        return toReturn;
    }
}