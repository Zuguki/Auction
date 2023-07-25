using FluentResults;
using MediatR;

namespace GG.Auction.Application.Auctions.Get;

public class GetAuctionsQueryHandler : IRequestHandler<GetAuctionsQuery, Result<IEnumerable<Domain.Auction>>>
{
    private readonly UnitOfWork unitOfWork;

    public GetAuctionsQueryHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<Domain.Auction>>> Handle(GetAuctionsQuery request,
        CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Auction> auctions;

        if (request.LastAuctionId.HasValue)
            auctions = (await unitOfWork.Auctions.GetAsync(cancellationToken))
                .Where(a => a.Id > request.LastAuctionId)
                .OrderBy(a => a.Id)
                .Take(50);
        else
            auctions = (await unitOfWork.Auctions.GetAsync(cancellationToken))
                .OrderBy(a => a.Id)
                .Take(50);

        return Result.Ok(auctions);
    }
}