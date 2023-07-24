using System.Collections.Concurrent;
using GG.Auction.Application;

namespace GG.Auction.Database.Auction;

public class InMemoryAuctionsRepository : IRepository<Domain.Auction>
{
    private readonly ConcurrentDictionary<int, Domain.Auction> auctions = new();

    public Task AddAsync(IEnumerable<Domain.Auction> objects, CancellationToken cancellationToken)
    {
        var nextId = auctions
            .Keys
            .OrderByDescending(r => r)
            .FirstOrDefault() + 1;
        
        foreach (var auction in objects)
        {
            auction.Id = nextId;
            auctions.TryAdd(nextId, auction);
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(IEnumerable<Domain.Auction> objects, CancellationToken cancellationToken)
    {
        foreach (var auction in objects)
            auctions.TryRemove(auction.Id, out _);
        
        return Task.CompletedTask;
    }

    public Task UpdateAsync(IEnumerable<Domain.Auction> objects, CancellationToken cancellationToken)
    {
        foreach (var auction in objects)
        {
            if (!auctions.TryGetValue(auction.Id, out var existedAuction))
                continue;
            
            existedAuction.UpdateName(auction.Name!);
            existedAuction.UpdateDateStart(auction.DateStart);
            existedAuction.UpdateDateEnd(auction.DateEnd);
            existedAuction.ChangeCreationState();

            if (auction.IsCanceled)
                existedAuction.Cancel();
        }

        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<Domain.Auction>> GetAsync(CancellationToken cancellationToken) =>
        Task.FromResult<IReadOnlyCollection<Domain.Auction>>(auctions.Values.ToArray());
}