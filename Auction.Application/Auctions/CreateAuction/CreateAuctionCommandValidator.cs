using Auction.Application.Mediator;
using FluentResults;

namespace Auction.Application.Auctions.CreateAuction;

public class CreateAuctionCommandValidator : IValidator<CreateAuctionCommand>
{
    public Result Validate(CreateAuctionCommand? request)
    {
        if (request is null)
            return Result.Fail("Не удалось распознать данные.");

        if (string.IsNullOrWhiteSpace(request.Name))
            return Result.Fail("Переданно пустое имя.");
        
        if (request.DateEnd == default)
            return Result.Fail("Передана некорректная дата завершения аукциона.");
        
        if (request.DateStart == default)
            return Result.Fail("Передана некорректная дата начала аукциона.");
        
        if (request.DateEnd <= request.DateStart)
            return Result.Fail("Дата завершения не может быть меньше или равна дате начала.");

        return Result.Ok();
    }
}