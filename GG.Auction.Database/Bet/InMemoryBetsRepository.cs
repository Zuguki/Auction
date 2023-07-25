using System.Collections.Concurrent;
using GG.Auction.Application;

namespace GG.Auction.Database.Bet;

public class InMemoryBetsRepository : IRepository<Domain.Bet>
{
    private readonly ConcurrentDictionary<Guid, Domain.Bet> _bets = new();

    public Task SaveAsync(IEnumerable<Domain.Bet> objects, CancellationToken cancellationToken)
    {
        foreach (var bet in objects)
        {
            if (_bets.TryGetValue(bet.Id, out _)) 
                continue;
            
            _bets.TryAdd(bet.Id, bet);
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(IEnumerable<Domain.Bet> objects, CancellationToken cancellationToken)
    {
        foreach (var bet in objects)
        {
            _bets.TryRemove(bet.Id, out _);
        }
        
        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<Domain.Bet>> GetAsync(CancellationToken cancellationToken) =>
        Task.FromResult<IReadOnlyCollection<Domain.Bet>>(_bets.Values.ToArray());
}