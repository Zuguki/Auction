using FluentResults;
using GG.Auction.Application.Mediator;

namespace GG.Auction.Application.Lots.GetLotsByAuctionIdQuery;

public class GetLotsByAuctionIdQueryValidator : IValidator<GetLotsByAuctionIdQuery>
{
    public Result Validate(GetLotsByAuctionIdQuery? request)
    {
        if (request?.AuctionId == Guid.Empty)
            return Result.Fail("Передан некорректный идентификатор ауцкиона");
        
        return Result.Ok();
    }
}