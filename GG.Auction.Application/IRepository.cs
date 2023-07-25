namespace GG.Auction.Application;

public interface IRepository<T>
{
    Task SaveAsync(IEnumerable<T> objects, CancellationToken cancellationToken);

    Task DeleteAsync(IEnumerable<T> objects, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<T>> GetAsync(CancellationToken cancellationToken);
}