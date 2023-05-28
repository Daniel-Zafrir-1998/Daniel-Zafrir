public class ExceptionResponse
{
    public string Title { get; init; } = null!;
    public int StatusCode { get; init; }
    public string Massage { get; init; } = null!;
    public IEnumerable<object> Errors { get; init; } = null!;
}