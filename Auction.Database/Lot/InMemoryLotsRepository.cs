using Auction.Application;
using ChangeCreationStateAuctionCommand.Application;

namespace ChangeCreationStateAuctionCommand.Database.Lot;

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