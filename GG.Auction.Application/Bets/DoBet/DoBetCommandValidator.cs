using FluentResults;
using GG.Auction.Application.Mediator;

namespace GG.Auction.Application.Bets.DoBet;

public class DoBetCommandValidator : IValidator<DoBetCommand>
{
    public Result Validate(DoBetCommand? request)
    {
        if (request?.LotId == Guid.Empty)
            return Result.Fail("Передан некорректный формат данных");
        
        return Result.Ok();
    }
}