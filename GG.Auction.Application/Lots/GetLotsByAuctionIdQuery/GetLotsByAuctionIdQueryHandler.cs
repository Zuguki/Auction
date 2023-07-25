using FluentResults;
using GG.Auction.Domain;
using MediatR;

namespace GG.Auction.Application.Lots.GetLotsByAuctionIdQuery;

public class GetLotsByAuctionIdQueryHandler : IRequestHandler<GetLotsByAuctionIdQuery, Result<IEnumerable<Lot>>>
{
    private readonly UnitOfWork unitOfWork;

    public GetLotsByAuctionIdQueryHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<Lot>>> Handle(GetLotsByAuctionIdQuery request,
        CancellationToken cancellationToken)
    {
        var lots = await unitOfWork.Lots
            .GetAsync(cancellationToken);

        return Result.Ok<IEnumerable<Lot>>(lots);
    }

}