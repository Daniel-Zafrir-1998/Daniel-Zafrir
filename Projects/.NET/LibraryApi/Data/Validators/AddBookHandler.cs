using FluentValidation;

public sealed class AddBookValidator : AbstractValidator<AddBookCommand>
{
    public AddBookValidator()
    {
        RuleFor(x => x.BookRequest).SetValidator(new BookRequestModelValidator());
    }
}