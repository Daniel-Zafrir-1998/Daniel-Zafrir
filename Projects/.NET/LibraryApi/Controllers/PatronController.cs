using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PatronController : ControllerBase
{
    private readonly ILogger<PatronController> _logger;
    public PatronController(ILogger<PatronController> logger)
    {
        _logger = logger;
    }
    [HttpGet()]
    public async Task<List<PatronResponseModel>> GetAllPatron()
    {
        return Ok();
    }
    [HttpGet("{PatronID}")]
    public async Task<PatronResponseModel> GetPatron([FromRoute] int PatronID)
    {
        return Ok();
    }
    [HttpPost()]
    public async Task<bool> AddPatron([FromBody] PatronRequestModel requestModel)
    {
        return Ok();
    }
    [HttpPut()]
    public async Task<bool> UpdatePatron([FromBody] PatronRequestModel requestModel)
    {
        return Ok();
    }
}