using GG.Auction.Application;

namespace GG.Auction.Database.Bet;

public class InMemoryBetsRepository : IRepository<Domain.Bet>
{
    public Task AddAsync(IEnumerable<Domain.Bet> objects, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(IEnumerable<Domain.Bet> objects, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(IEnumerable<Domain.Bet> objects, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Domain.Bet>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}