using FluentResults;
using GG.Auction.Application.Mediator;

namespace GG.Auction.Application.Auctions.Update;

public class UpdateAuctionCommandValidator : IValidator<UpdateAuctionCommand>
{
    public Result Validate(UpdateAuctionCommand? request)
    {
        if (request is null)
            return Result.Fail("Не удалось распознать данные.");

        if (string.IsNullOrWhiteSpace(request.Name))
            return Result.Fail("Переданно пустое имя.");
        
        if (request.DateEnd == default)
            return Result.Fail("Передана некорректная новая дата завершения аукциона.");
        
        if (request.DateStart == default)
            return Result.Fail("Передана некорректная новая дата начала аукциона.");
        
        if (request.DateEnd <= request.DateStart)
            return Result.Fail("Дата завершения не может быть меньше или равна дате начала.");

        return Result.Ok();
    }
}