using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    public AuthorController(ILogger<AuthorController> logger)
    {
        _logger = logger;
    }
    [HttpGet()]
    public async Task<List<AuthorResponseModel>> GetAllAuthor()
    {
        return Ok();
    }
    [HttpGet("{AuthorID}")]
    public async Task<AuthorResponseModel> GetAuthor([FromRoute] int AuthorID)
    {
        return Ok();
    }
    [HttpPost()]
    public async Task<bool> AddAuthor([FromBody] AuthorRequestModel requestModel)
    {
        return Ok();
    }
    [HttpPut()]
    public async Task<bool> UpdateAuthor([FromBody] AuthorRequestModel requestModel)
    {
        return Ok();
    }
}