using Auction.Application;

namespace Auction.Database.Lot;

public class InMemoryLotsRepository : IRepository<Domain.Lot>
{
    public Task AddAsync(IEnumerable<Domain.Lot> objects, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(IEnumerable<Domain.Lot> objects, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(IEnumerable<Domain.Lot> objects, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Domain.Lot>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}