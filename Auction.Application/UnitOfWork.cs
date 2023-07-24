using Auction.Application;
using ChangeCreationStateAuctionCommand.Domain;

namespace ChangeCreationStateAuctionCommand.Application;

public class UnitOfWork
{
    public IRepository<Domain.Auction> Auctions { get; }
    public IRepository<Domain.Bet> Bets { get; }
    public IRepository<Domain.Lot> Lots { get; }

    public UnitOfWork(IRepository<Domain.Auction> auctions, IRepository<Bet> bets, IRepository<Lot> lots)
    {
        Auctions = auctions;
        Bets = bets;
        Lots = lots;
    }
}