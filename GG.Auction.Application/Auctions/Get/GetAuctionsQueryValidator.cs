using FluentResults;
using GG.Auction.Application.Mediator;

namespace GG.Auction.Application.Auctions.Get;

public class GetAuctionsQueryValidator : IValidator<GetAuctionsQuery>
{
    public Result Validate(GetAuctionsQuery? request)
    {
        if (request is null)
            return Result.Fail("Не удалось распознать данные.");

        if (request.LastAuctionId is <= 0)
            return Result.Fail("Передан некорректный идентификатор аукиона.");

        return Result.Ok();
    }
}