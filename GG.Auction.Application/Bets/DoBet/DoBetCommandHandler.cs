using FluentResults;
using MediatR;

namespace GG.Auction.Application.Bets.DoBet;

public class DoBetCommandHandler : IRequestHandler<DoBetCommand, Result>
{
    private readonly UnitOfWork unitOfWork;

    public DoBetCommandHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DoBetCommand request, CancellationToken cancellationToken)
    {
        var auction = (await unitOfWork.Auctions.GetAsync(cancellationToken))
            .FirstOrDefault(a => a.Id == request.AuctionId);

        if (auction is null)
            return Result.Fail("Нельзя обновить данный лот, т.к. для ауцкиона запрещено редактирование");

        var result = auction.DoBet(request.LotId, Guid.NewGuid());
        if (result.IsFailed)
            return Result.Fail(result.Errors);

        await unitOfWork.Bets.SaveAsync(new[] {result.Value}, cancellationToken);
        return Result.Ok();
    }
}