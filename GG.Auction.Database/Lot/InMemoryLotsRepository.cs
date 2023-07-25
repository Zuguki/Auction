using System.Collections.Concurrent;
using GG.Auction.Application;

namespace GG.Auction.Database.Lot;

public class InMemoryLotsRepository : IRepository<Domain.Lot>
{
    private readonly ConcurrentDictionary<Guid, Domain.Lot> _lots = new();
    
    public Task SaveAsync(IEnumerable<Domain.Lot> objects, CancellationToken cancellationToken)
    {
        foreach (var lot in objects)
        {
            if (_lots.ContainsKey(lot.Id))
                continue;

            _lots.TryAdd(lot.Id, lot);
        }
        
        return Task.CompletedTask;
    }

    public Task DeleteAsync(IEnumerable<Domain.Lot> objects, CancellationToken cancellationToken)
    {
        foreach (var lot in objects)
        {
            _lots.TryRemove(lot.Id, out _);
        }
        
        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<Domain.Lot>> GetAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult<IReadOnlyCollection<Domain.Lot>>(_lots.Values.ToArray());
    }
}