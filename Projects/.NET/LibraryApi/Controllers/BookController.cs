using Microsoft.AspNetCore.Mvc;
using MediatR;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IMediator _mediator;
    public BookController(ILogger<BookController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    [HttpGet()]
    public async Task<List<BookResponseModel>> GetAllBook()
    {
        var x = await _mediator.Send(new GetAllBooksQuery());
        return null;
    }
    [HttpGet("{bookID}")]
    public async Task<BookResponseModel> GetBook([FromRoute] int bookID)
    {
        return Ok();
    }
    [HttpPost()]
    public async Task<BookRequestModel> AddBook([FromBody] BookRequestModel requestModel)
    {
        return Ok();
    }
    [HttpPut()]
    public async Task<bool> UpdateBook([FromBody] BookRequestModel requestModel)
    {
        return Ok();
    }
}