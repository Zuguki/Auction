using FluentResults;
using MediatR;

namespace GG.Auction.Application.Lots.Create;

public class CreateLotCommandHandler : IRequestHandler<CreateLotCommand, Result>
{
    private readonly UnitOfWork unitOfWork;

    public CreateLotCommandHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateLotCommand request, CancellationToken cancellationToken)
    {
        var auction = (await unitOfWork.Auctions.GetAsync(cancellationToken))
            .FirstOrDefault(auc => auc.Id == request.AuctionId);
        
        if (auction is null)
            return Result.Fail("Аукцион с переданным идентификатором не найден");

        var result = auction.AddLot(request.Name!, request.Code!, request.Description!, request.BetStep,
            request.BuyoutPrice);
        
        if (result.IsFailed)
            return Result.Fail(result.Errors);
        
        await unitOfWork.Lots.SaveAsync(new [] { result.Value }, cancellationToken);
        return Result.Ok();
    }
}