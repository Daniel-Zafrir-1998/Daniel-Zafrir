using MediatR;
using AutoMapper;

public class UpdatePatronHandler : IRequestHandler<UpdatePatronCommand, PatronRequestModel>
{
    private readonly LibraryContext _context;
    private readonly IMapper _mapper;

    public UpdatePatronHandler(LibraryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PatronRequestModel> Handle(UpdatePatronCommand request, CancellationToken cancellationToken)
    {
        var Patron = _context.Patrons.Where(x => x.ID == request.PatronRequest.ID).First();

        _mapper.Map(request.PatronRequest, Patron);

        await _context.SaveChangesAsync();

        return request.PatronRequest;
    }
}