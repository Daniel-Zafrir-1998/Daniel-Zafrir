using FluentValidation;
using FluentValidation.Results;

public static class EnumerableExtantions
{
    public static IEnumerable<ValidationResult> Validate<TValidator, TRequest, TResponse>(this IEnumerable<IValidator> validators, ValidationContext<TRequest> context)
    where TValidator : IValidator
    where TRequest : class, ICommand<TResponse>
    {
        return validators.Select(x => x.Validate(context));
    }
}