using FluentValidation;

public sealed class BookRequestModelValidator : AbstractValidator<BookRequestModel>
{
    public BookRequestModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.AuthorID).NotEmpty();
        RuleFor(x => x.GenreID).NotEmpty();
    }
}