using MediatR;
using AutoMapper;
public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookResponseModel>>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;
    public GetAllBooksHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<BookResponseModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var response = _context.Books
                               .Select(x => _mapper.Map<Book, BookResponseModel>(x))
                               .ToList();

        await Task.CompletedTask;

        return response;
    }
}