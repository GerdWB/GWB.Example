namespace GWB.Example.Application.Core.Behaviors;

using FluentValidation;
using MediatR;
using ValidationException = Exceptions.ValidationException;

public sealed class CommandsValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>, ICommand
    where TResponse : CommandResult
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public CommandsValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errorsDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(
                keySelector: x => x.PropertyName,
                elementSelector: x => x.ErrorMessage,
                resultSelector: (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(keySelector: x => x.Key, elementSelector: x => x.Values);

        if (errorsDictionary.Any())
        {
            throw new ValidationException(errorsDictionary);
        }

        return await next();
    }
}