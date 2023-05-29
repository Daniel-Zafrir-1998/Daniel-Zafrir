using FluentValidation;

public abstract class GenreRequestModelValidator : AbstractValidator<GenreRequestModel>
{
    public GenreRequestModelValidator()
    {
        RuleFor(x => x.ID).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}