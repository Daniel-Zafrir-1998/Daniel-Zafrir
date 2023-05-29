using MediatR;
using AutoMapper;

public class AddAuthorHandler : IRequestHandler<AddAuthorCommand, AuthorRequestModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;

    public AddAuthorHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AuthorRequestModel> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Author>(request.AuthorRequest);

        await _context.AddAsync(author);
        await _context.SaveChangesAsync();

        return request.AuthorRequest;
    }
}