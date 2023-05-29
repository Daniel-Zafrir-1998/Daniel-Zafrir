using MediatR;
using AutoMapper;

public class GetBookHandler : IRequestHandler<GetBookQuery, BookResponseModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;
    public GetBookHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    public async Task<BookResponseModel> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FindAsync(request.BookID);
        var toReturn = _mapper.Map<BookResponseModel>(book);

        return toReturn;
    }
}