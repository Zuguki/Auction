using GG.Auction.Application.Auctions.Cancel;
using FluentResults;
using GG.Auction.Application.Mediator;

namespace GG.Auction.Application.Auctions.ChangeCreationAuction;

public class ChangeAuctionCreationStateCommandValidator : IValidator<ChangeAuctionCreationStateCommand>
{
    public Result Validate(ChangeAuctionCreationStateCommand? request)
    {
        if (request is null)
            return Result.Fail("Не удалось распознать данные.");
        if (request.AuctionId <= 0)
            return Result.Fail("Передан некорректный идентификатор.");

        return Result.Ok();
    }
}