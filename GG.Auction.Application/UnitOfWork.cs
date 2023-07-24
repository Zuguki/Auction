using GG.Auction.Domain;

namespace GG.Auction.Application;

public class UnitOfWork
{
    public IRepository<GG.Auction.Domain.Auction> Auctions { get; }
    public IRepository<Bet> Bets { get; }
    public IRepository<Lot> Lots { get; }

    public UnitOfWork(IRepository<GG.Auction.Domain.Auction> auctions, IRepository<Bet> bets, IRepository<Lot> lots)
    {
        Auctions = auctions;
        Bets = bets;
        Lots = lots;
    }
}