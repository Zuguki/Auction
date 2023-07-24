using FluentResults;
using MediatR;

namespace GG.Auction.Application.Auctions.Cancel;

public class CancelAuctionCommandHandler : IRequestHandler<CancelAuctionCommand, Result>
{
    private readonly UnitOfWork unitOfWork;

    public CancelAuctionCommandHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CancelAuctionCommand request, CancellationToken cancellationToken)
    {
        var allAuctions = await unitOfWork.Auctions.GetAsync(cancellationToken);
        var existedAuction = allAuctions.FirstOrDefault(auction => auction.Id == request.AuctionId);

        if (existedAuction is null)
            return Result.Fail("Аукциона с переданным аунтефикатором не существует.");

        if (!existedAuction.IsEditable)
            return Result.Fail("Данный аукцион нельзя отменить.");

        existedAuction.Cancel();
        await unitOfWork.Auctions.UpdateAsync(new[] { existedAuction }, cancellationToken);
        
        return Result.Ok();
    }
}