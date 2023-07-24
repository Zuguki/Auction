using FluentResults;
using MediatR;

namespace GG.Auction.Application.Auctions.Delete;

public class DeleteAuctionCommandHandler : IRequestHandler<DeleteAuctionCommand, Result>
{
    private readonly UnitOfWork unitOfWork;

    public DeleteAuctionCommandHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAuctionCommand request, CancellationToken cancellationToken)
    {
        var auctions = await unitOfWork.Auctions.GetAsync(cancellationToken);
        var existedAuction = auctions.FirstOrDefault(auc => auc.Id == request.AuctionId);

        if (existedAuction is null)
            return Result.Fail("Такого аукционна не существует.");
        
        if (!existedAuction.IsEditable)
            return Result.Fail("Данный аукцион нельзя удалить.");

        await unitOfWork.Auctions.DeleteAsync(new[] { existedAuction }, cancellationToken);
        return Result.Ok();
    }
}