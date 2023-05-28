using FluentValidation;
using FluentValidation.Results;
using MediatR;

public sealed class ValidationBehavior<TRequest, TResponse> : IValidationBehavior<TRequest, TResponse>
where TRequest : class, ICommand<TResponse>
{
    private readonly IEnumerable<IValidator> _validators;
    private readonly ValidationContext<TRequest> _context;
    public ValidationBehavior(IEnumerable<IValidator> validators, ValidationContext<TRequest> context)
    {
        _validators = validators;
        _context = context;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        IEnumerable<ValidationResult> validationResults = _validators.Validate<IValidator, TRequest, TResponse>(_context);
        IEnumerable<ValidationFailure> errorsResults = FindAndGroupErrors(validationResults);

        AssertErrors(errorsResults);

        return await next();
    }
    private IEnumerable<ValidationFailure> FindAndGroupErrors(IEnumerable<ValidationResult> validationResults)
    {
        return validationResults.SelectMany(x => x.Errors);
    }
    private void AssertErrors(IEnumerable<ValidationFailure> errorsResults)
    {
        if (errorsResults.Any())
        {
            throw new ValidationException(errorsResults);
        }
    }
}