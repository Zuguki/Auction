using FluentResults;
using MediatR;

namespace Auction.Application.Auctions.CreateAuction;

public class CreateAuctionCommandHandler : IRequestHandler<CreateAuctionCommand, ResultBase>
{
    public Task<ResultBase> Handle(CreateAuctionCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult<ResultBase>(Result.Ok(Guid.NewGuid()));
    }
}