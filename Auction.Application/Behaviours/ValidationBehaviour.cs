using ChangeCreationStateAuctionCommand.Application.Mediator;
using FluentResults;
using MediatR;

namespace ChangeCreationStateAuctionCommand.Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TResponse : ResultBase, new() 
    where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest> validator;

    public ValidationBehaviour(IValidator<TRequest> validator)
    {
        this.validator = validator;
    }

    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);
        if (validationResult.IsFailed)
        {
            var result = new TResponse();
            result.Reasons.AddRange(validationResult.Reasons);
            return result;
        }

        return await next();
    }
}