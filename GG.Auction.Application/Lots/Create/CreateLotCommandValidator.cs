using FluentResults;
using GG.Auction.Application.Mediator;

namespace GG.Auction.Application.Lots.Create;

public class CreateLotCommandValidator : IValidator<CreateLotCommand>
{
    public Result Validate(CreateLotCommand? request)
    {
        if (request is null)
            return Result.Fail("Передан некорректный формат данных");
        
        if (request.AuctionId == Guid.Empty)
            return Result.Fail("Передан некорректный идентификатор аукциона");
        
        if (request.BetStep <= 0m)
            return Result.Fail("Шаг ставки не может быть меньше или равен нуля");
        
        if (request.BuyoutPrice <= 0m)
            return Result.Fail("Стоимость выкупа не может быть меньше или равна нуля");
        
        if (string.IsNullOrWhiteSpace(request.Code))
            return Result.Fail("Передан пустой код");
        
        if (string.IsNullOrWhiteSpace(request.Name))
            return Result.Fail("Передано пустое название лота");
        
        if (string.IsNullOrWhiteSpace(request.Description))
            return Result.Fail("Передано пустое описание лота");

        return Result.Ok();
    }
}