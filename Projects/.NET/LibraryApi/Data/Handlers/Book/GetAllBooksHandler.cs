using System.Linq;
using MediatR;

public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
{
    private readonly LibraryContext _context;
    public GetAllBooksHandler(LibraryContext context)
    {
        _context = context;
    }
    public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_context.Books.ToList());
    }
}