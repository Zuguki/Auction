using System.Collections.Concurrent;
using GG.Auction.Application;

namespace GG.Auction.Database.Auction;

public class InMemoryAuctionsRepository : IRepository<Domain.Auction>
{
    private readonly ConcurrentDictionary<Guid, Domain.Auction> auctions = new();

    public Task SaveAsync(IEnumerable<Domain.Auction> objects, CancellationToken cancellationToken)
    {
        foreach (var auction in objects)
        {
            if (auctions.TryGetValue(auction.Id, out _)) 
                continue;
            
            auctions.TryAdd(auction.Id, auction);
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(IEnumerable<Domain.Auction> objects, CancellationToken cancellationToken)
    {
        foreach (var auction in objects)
            auctions.TryRemove(auction.Id, out _);
        
        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<Domain.Auction>> GetAsync(CancellationToken cancellationToken) =>
        Task.FromResult<IReadOnlyCollection<Domain.Auction>>(auctions.Values.ToArray());
}