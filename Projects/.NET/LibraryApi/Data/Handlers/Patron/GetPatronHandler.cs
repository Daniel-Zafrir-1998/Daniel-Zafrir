using MediatR;
using AutoMapper;

public class GetPatronHandler : IRequestHandler<GetPatronQuery, PatronResponseModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;
    public GetPatronHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    public async Task<PatronResponseModel> Handle(GetPatronQuery request, CancellationToken cancellationToken)
    {
        var Patron = await _context.Patrons.FindAsync(request.PatronID);
        var toReturn = _mapper.Map<PatronResponseModel>(Patron);

        return toReturn;
    }
}