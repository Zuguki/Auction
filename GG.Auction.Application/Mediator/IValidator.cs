using FluentResults;
using MediatR;

namespace GG.Auction.Application.Mediator;

public interface IValidator<in T> where T : IBaseRequest
{
    Result Validate(T request);
}