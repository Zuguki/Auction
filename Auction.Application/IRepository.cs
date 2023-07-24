namespace Auction.Application;

public interface IRepository<T>
{
    Task AddAsync(IEnumerable<T> objects, CancellationToken cancellationToken);

    Task DeleteAsync(IEnumerable<T> objects, CancellationToken cancellationToken);

    Task UpdateAsync(IEnumerable<T> objects, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<T>> GetAsync(CancellationToken cancellationToken);
}