using FluentResults;
using GG.Auction.Application.Mediator;

namespace GG.Auction.Application.Lots.Delete;

public class DeleteLotCommandValidator : IValidator<DeleteLotCommand>
{
    public Result Validate(DeleteLotCommand? request)
    {
        if (request?.LotId == Guid.Empty)
            return Result.Fail("Передан некорректный идентификатор лота");
        
        return Result.Ok();
    }
}