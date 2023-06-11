using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly ILogger<GenreController> _logger;
    private readonly IMediator _mediator;
    public GenreController(ILogger<GenreController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    [HttpGet()]
    public async Task<List<GenreResponseModel>> GetAllGenre()
    {
        var result = await _mediator.Send(new GetAllGenresQuery());

        return result;
    }
    [HttpGet("{genreID}")]
    public async Task<GenreResponseModel> GetGenre([FromRoute] int genreID)
    {
        var result = await _mediator.Send(new GetGenreQuery(genreID));

        return result;
    }
    [HttpPost()]
    public async Task<GenreRequestModel> AddGenre([FromBody] GenreRequestModel requestModel)
    {
        var result = await _mediator.Send(new AddGenreCommand(requestModel));

        return result;
    }
    [HttpPut()]
    public async Task<GenreRequestModel> UpdateGenre([FromBody] GenreRequestModel requestModel)
    {
        var result = await _mediator.Send(new UpdateGenreCommand(requestModel));

        return result;
    }
}