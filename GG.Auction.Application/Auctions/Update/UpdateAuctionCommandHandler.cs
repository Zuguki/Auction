using FluentResults;
using MediatR;

namespace GG.Auction.Application.Auctions.Update;

public class UpdateAuctionCommandHandler : IRequestHandler<UpdateAuctionCommand, Result>
{
    private readonly UnitOfWork unitOfWork;

    public UpdateAuctionCommandHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAuctionCommand request, CancellationToken cancellationToken)
    {
        var auctions = await unitOfWork.Auctions.GetAsync(cancellationToken);
        var existedAuction = auctions.FirstOrDefault(auc => auc.Id == request.AuctionId);

        if (existedAuction is null)
            return Result.Fail("По данному идентификатору аукцион не найден.");
        
        if (!existedAuction.IsEditable)
            return Result.Fail("По данному аукциону запрещенно менять правила.");

        await unitOfWork.Auctions.SaveAsync(new[] {existedAuction}, cancellationToken);

        return Result.Ok();
    }
}