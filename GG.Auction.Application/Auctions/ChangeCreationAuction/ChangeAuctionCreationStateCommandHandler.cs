using GG.Auction.Application.Auctions.Cancel;
using FluentResults;
using MediatR;

namespace GG.Auction.Application.Auctions.ChangeCreationAuction;

public class ChangeAuctionCreationStateCommandHandler : IRequestHandler<ChangeAuctionCreationStateCommand, Result>
{
    private readonly UnitOfWork unitOfWork;

    public ChangeAuctionCreationStateCommandHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ChangeAuctionCreationStateCommand request, CancellationToken cancellationToken)
    {
        var allAuctions = await unitOfWork.Auctions.GetAsync(cancellationToken);
        var existedAuction = allAuctions.FirstOrDefault(auction => auction.Id == request.AuctionId);

        if (existedAuction is null)
            return Result.Fail("Аукциона с переданным аунтефикатором не существует.");

        if (!existedAuction.IsEditable) 
            return Result.Fail("У данного аукционна нельзя изменить статус.");

        existedAuction.ChangeCreationState();
        await unitOfWork.Auctions.SaveAsync(new[] { existedAuction }, cancellationToken);

        return Result.Ok();
    }
}