using Microsoft.AspNetCore.Mvc;
using MediatR;

[ApiController]
[Route("api/[controller]")]
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
        var result = await _mediator.Send(new GetAllBooksQuery());

        return result;
    }

    [HttpGet("{bookID}")]
    public async Task<BookResponseModel> GetBook([FromRoute] int bookID)
    {
        var result = await _mediator.Send(new GetBookQuery(bookID));

        return result;
    }

    [HttpPost()]
    public async Task<BookRequestModel> AddBook([FromBody] BookRequestModel requestModel)
    {
        var result = await _mediator.Send(new AddBookCommand(requestModel));

        return result;
    }

    [HttpPut()]
    public async Task<BookRequestModel> UpdateBook([FromBody] BookRequestModel requestModel)
    {
        var result = await _mediator.Send(new UpdateBookCommand(requestModel));

        return result;
    }
}