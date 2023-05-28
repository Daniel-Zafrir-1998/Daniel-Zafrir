using MediatR;
using AutoMapper;

public class AddBookHandler : IRequestHandler<AddBookCommand, BookRequestModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;

    public AddBookHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BookRequestModel> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(request.BookRequest);

        await _context.AddAsync(book);
        await _context.SaveChangesAsync();

        return request.BookRequest;
    }
}