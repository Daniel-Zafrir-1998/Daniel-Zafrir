using FluentValidation;

public abstract class PatronRequestModelValidator : AbstractValidator<PatronRequestModel>
{
    public PatronRequestModelValidator()
    {
        RuleFor(x => x.ID).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty();
    }
}