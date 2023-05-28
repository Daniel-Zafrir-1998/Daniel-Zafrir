public class BadRequestException : Exception
{
    public BadRequestException(string massage) : base(massage)
    { }
}