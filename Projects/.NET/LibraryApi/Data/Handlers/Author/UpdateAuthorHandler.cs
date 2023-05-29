using MediatR;
using AutoMapper;

public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, AuthorRequestModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;

    public UpdateAuthorHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AuthorRequestModel> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var Author = _context.Authors.Where(x => x.ID == request.AuthorRequest.ID).First();

        _mapper.Map(request.AuthorRequest, Author);

        await _context.SaveChangesAsync();

        return request.AuthorRequest;
    }
}