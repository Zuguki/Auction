using FluentResults;
using GG.Auction.Application.Mediator;

namespace GG.Auction.Application.Auctions.Delete;

public class DeleteAuctionCommandValidator : IValidator<DeleteAuctionCommand>
{
    public Result Validate(DeleteAuctionCommand? request)
    {
        if (request is null)
            return Result.Fail("Не удалось распознать данные.");
        
        if (request.AuctionId == Guid.NewGuid())
            return Result.Fail("Переданн некорректный идентификатор.");

        return Result.Ok();
    }
}