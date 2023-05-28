using MediatR;

public interface IValidationBehavior<in TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : class, ICommand<TResponse>
{

}