namespace GG.Auction.Domain;

public class Bet
{
    public int Id { get; init; }
    public int AuthorId { get; init; }
    public int LotId { get; init; }
    public decimal Amount { get; init; }
    public DateTime DateTime { get; init; }
}