namespace GG.Auction.Domain;

public class Bet
{
    public Guid Id { get; init; }
    public Guid AuthorId { get; init; }
    public Guid LotId { get; init; }
    public decimal Amount { get; init; }
    public DateTime DateTime { get; init; }
}