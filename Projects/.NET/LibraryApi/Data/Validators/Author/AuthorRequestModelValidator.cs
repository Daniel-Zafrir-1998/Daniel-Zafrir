using FluentValidation;

public abstract class AuthorRequestModelValidator : AbstractValidator<AuthorRequestModel>
{
    public AuthorRequestModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.ID).NotEmpty();
    }
}