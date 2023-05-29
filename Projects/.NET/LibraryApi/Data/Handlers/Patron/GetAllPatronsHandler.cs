using MediatR;
using AutoMapper;
public class GetAllPatronsHandler : IRequestHandler<GetAllPatronsQuery, List<PatronResponseModel>>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;
    public GetAllPatronsHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<PatronResponseModel>> Handle(GetAllPatronsQuery request, CancellationToken cancellationToken)
    {
        var response = _context.Patrons
                               .Select(x => _mapper.Map<Patron, PatronResponseModel>(x))
                               .ToList();

        await Task.CompletedTask;

        return response;
    }
}