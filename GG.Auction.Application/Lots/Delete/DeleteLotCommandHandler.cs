using FluentResults;
using MediatR;

namespace GG.Auction.Application.Lots.Delete;

public class DeleteLotCommandHandler : IRequestHandler<DeleteLotCommand, Result>
{
    private readonly UnitOfWork unitOfWork;

    public DeleteLotCommandHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteLotCommand request, CancellationToken cancellationToken)
    {
        var auction = (await unitOfWork.Auctions
            .GetAsync(cancellationToken))
            .FirstOrDefault(a => a.Id == request.AuctionId);

        if (auction is null)
            return Result.Fail("Аукциона по указанному идентификатору не найден");

        var result = auction.RemoveLot(request.LotId);
        if (result.IsFailed)
            return Result.Fail(result.Errors);
        
        await unitOfWork.Lots.DeleteAsync(new[] { result.Value }, cancellationToken);
        return Result.Ok();
    }
}