using FluentResults;
using MediatR;

namespace Auction.Application.Auctions.CreateAuction;

public class CreateAuctionCommandHandler : IRequestHandler<CreateAuctionCommand, Result>
{
    public Task<Result> Handle(CreateAuctionCommand request, CancellationToken cancellationToken)
    {
        // return Task.FromResult<ResultBase>(Result.Ok(Guid.NewGuid()));
        return Task.FromResult(Result.Ok());
    }
}