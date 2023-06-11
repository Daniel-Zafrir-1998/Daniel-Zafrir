using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly IMediator _mediator;
    public AuthorController(ILogger<AuthorController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<List<AuthorResponseModel>> GetAllAuthors()
    {
        var result = await _mediator.Send(new GetAllAuthorsQuery());

        return result;
    }

    [HttpGet("{authorID}")]
    public async Task<AuthorResponseModel> GetAuthor([FromRoute] int authorID)
    {
        var result = await _mediator.Send(new GetAuthorQuery(authorID));

        return result;
    }

    [HttpPost()]
    public async Task<AuthorRequestModel> AddAuthor([FromBody] AuthorRequestModel requestModel)
    {
        var result = await _mediator.Send(new AddAuthorCommand(requestModel));

        return result;
    }

    [HttpPut()]
    public async Task<AuthorRequestModel> UpdateAuthor([FromBody] AuthorRequestModel requestModel)
    {
        var result = await _mediator.Send(new UpdateAuthorCommand(requestModel));

        return result;
    }
}