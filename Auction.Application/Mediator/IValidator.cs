using FluentResults;
using MediatR;

namespace Auction.Application.Mediator;

public interface IValidator<in T> where T : IBaseRequest
{
    Result Validate(T request);
}