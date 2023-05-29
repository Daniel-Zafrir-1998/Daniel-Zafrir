using FluentValidation;

public abstract class BookRequestModelValidator : AbstractValidator<BookRequestModel>
{
    public BookRequestModelValidator()
    {
        RuleFor(x => x.ID).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.AuthorID).NotEmpty();
        RuleFor(x => x.GenreID).NotEmpty();
    }
}