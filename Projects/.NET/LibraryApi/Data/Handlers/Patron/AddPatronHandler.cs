using MediatR;
using AutoMapper;

public class AddPatronHandler : IRequestHandler<AddPatronCommand, PatronRequestModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;

    public AddPatronHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PatronRequestModel> Handle(AddPatronCommand request, CancellationToken cancellationToken)
    {
        var Patron = _mapper.Map<Patron>(request.PatronRequest);

        await _context.AddAsync(Patron);
        await _context.SaveChangesAsync();

        return request.PatronRequest;
    }
}