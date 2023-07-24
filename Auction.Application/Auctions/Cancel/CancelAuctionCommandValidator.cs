using ChangeCreationStateAuctionCommand.Application.Mediator;
using FluentResults;

namespace Auction.Application.Auctions.Cancel;

public class CancelAuctionCommandValidator : IValidator<CancelAuctionCommand>
{
    public Result Validate(CancelAuctionCommand? request)
    {
        if (request is null)
            return Result.Fail("Не удалось распознать данные.");
        if (request.AuctionId <= 0)
            return Result.Fail("Передан некорректный идентификатор.");

        return Result.Ok();
    }
}