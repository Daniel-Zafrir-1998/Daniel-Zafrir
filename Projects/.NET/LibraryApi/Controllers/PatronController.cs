using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/api")]
public class PatronController : ControllerBase
{
    private readonly ILogger<PatronController> _logger;
    private readonly IMediator _mediator;
    public PatronController(ILogger<PatronController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<List<PatronResponseModel>> GetAllPatron()
    {
        var result = await _mediator.Send(new GetAllPatronsQuery());

        return result;
    }
    [HttpGet("{patronID}")]
    public async Task<PatronResponseModel> GetPatron([FromRoute] int patronID)
    {
        var result = await _mediator.Send(new GetPatronQuery(patronID));

        return result;
    }
    [HttpPost()]
    public async Task<PatronRequestModel> AddPatron([FromBody] PatronRequestModel requestModel)
    {
        var result = await _mediator.Send(new AddPatronCommand(requestModel));

        return result;
    }
    [HttpPut()]
    public async Task<PatronRequestModel> UpdatePatron([FromBody] PatronRequestModel requestModel)
    {
        var result = await _mediator.Send(new UpdatePatronCommand(requestModel));

        return result;
    }
}