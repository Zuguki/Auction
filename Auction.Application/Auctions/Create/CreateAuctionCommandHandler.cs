using FluentResults;
using MediatR;

namespace Auction.Application.Auctions.Create;

public class CreateAuctionCommandHandler : IRequestHandler<CreateAuctionCommand, Result>
{
    private readonly UnitOfWork unitOfWork;

    public CreateAuctionCommandHandler(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateAuctionCommand request, CancellationToken cancellationToken)
    {
        var auction = new Domain.Auction(request.Name!, 0, request.DateStart, request.DateEnd);
        
        await unitOfWork.Auctions.AddAsync(new[] { auction }, cancellationToken);
        return Result.Ok();
    }
}