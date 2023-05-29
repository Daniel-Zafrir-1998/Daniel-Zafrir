using MediatR;
using AutoMapper;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, BookRequestModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;

    public UpdateBookHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BookRequestModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _context.Books.Where(x => x.ID == request.BookRequest.ID).First();

        _mapper.Map(request.BookRequest, book);

        await _context.SaveChangesAsync();

        return request.BookRequest;
    }
}