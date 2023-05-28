using FluentValidation;
using System.Text.Json;

public sealed class ExceptionHandlingMiddlewere : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddlewere> _logger;
    public ExceptionHandlingMiddlewere(ILogger<ExceptionHandlingMiddlewere> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode = GetStatusCode(exception);
        ExceptionResponse response = BuildExceptionResponse(exception, statusCode);

        await HandleHttpContext(context, response, statusCode);
    }


    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            BadRequestException badRequestException => StatusCodes.Status400BadRequest,
            NotFoundException notFoundException => StatusCodes.Status404NotFound,
            ValidationException validationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError,
        };
    private static string GetTitle(Exception exception) =>
    exception switch
    {
        _ => "ServerError",
    };

    private static IEnumerable<object> GetError(Exception exception) =>
    exception switch
    {
        ValidationException validationException => validationException.Errors,
        _ => Enumerable.Empty<object>(),
    };

    private static ExceptionResponse BuildExceptionResponse(Exception exception, int statusCode)
    {
        return new ExceptionResponse()
        {
            Title = GetTitle(exception),
            StatusCode = statusCode,
            Massage = exception.Message,
            Errors = GetError(exception),
        };
    }

    private static async Task HandleHttpContext(HttpContext context, ExceptionResponse response, int statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

}