using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly ILogger<GenreController> _logger;
    public GenreController(ILogger<GenreController> logger)
    {
        _logger = logger;
    }
    [HttpGet()]
    public async Task<List<GenreResponseModel>> GetAllGenre()
    {
        return Ok();
    }
    [HttpGet("{GenreID}")]
    public async Task<GenreResponseModel> GetGenre([FromRoute] int GenreID)
    {
        return Ok();
    }
    [HttpPost()]
    public async Task<bool> AddGenre([FromBody] GenreRequestModel requestModel)
    {
        return Ok();
    }
    [HttpPut()]
    public async Task<bool> UpdateGenre([FromBody] GenreRequestModel requestModel)
    {
        return Ok();
    }
}