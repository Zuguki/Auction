using FluentResults;
using MediatR;

namespace GG.Auction.Application.Lots.Update;

public class UpdateLotCommandHandler : IRequestHandler<UpdateLotCommand, Result>
{
    private readonly UnitOfWork unitOfWork;

    public UpdateLotCommandHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateLotCommand request, CancellationToken cancellationToken)
    {
        var auction = (await unitOfWork.Auctions
            .GetAsync(cancellationToken))
            .FirstOrDefault(a => a.Id == request.AuctionId);

        if (auction is null)
            return Result.Fail("Нельзя обновить данный лот, т.к. для ауцкиона запрещено редактирование");

        var result = auction.UpdateLot(request.LotId, request.Name, request.Code, request.Description, request.BetStep, request.BuyoutPrice);
        if (result.IsFailed)
            return Result.Fail(result.Errors);
        
        await unitOfWork.Lots.SaveAsync(new[] { result.Value }, cancellationToken);
        return Result.Ok();
    }
}