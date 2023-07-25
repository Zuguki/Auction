using FluentResults;
using MediatR;

namespace GG.Auction.Application.Auctions.Create;

public class CreateAuctionCommandHandler : IRequestHandler<CreateAuctionCommand, Result>
{
    private readonly UnitOfWork unitOfWork;

    public CreateAuctionCommandHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateAuctionCommand request, CancellationToken cancellationToken)
    {
        var auction = new GG.Auction.Domain.Auction(request.Name!, new Guid(), request.DateStart, request.DateEnd);
        
        await unitOfWork.Auctions.SaveAsync(new[] { auction }, cancellationToken);
        return Result.Ok();
    }
}