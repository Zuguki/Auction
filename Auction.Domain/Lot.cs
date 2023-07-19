using FluentResults;

namespace Auction.Domain;

public class Lot
{
    public int Id { get; init; }
    public int AuctionId { get; init; }
    public string? Name { get; init; }
    public string? Code { get; init; }
    public string? Description { get; init; }
    public LotStatus Status { get; init; }
    public IReadOnlyCollection<Bet> Bets => bets;
    public IReadOnlyCollection<string> Images { get; init; } = new List<string>();

    private List<Bet> bets = new();

    public Result TryDoBet(Bet bet)
    {
        if (Status == LotStatus.Complete)
            return Result.Fail("На данный лот невозможно сделать ставку, торги завершенны.");
        
        if (Bets.Any(b => b.Amount >= bet.Amount))
            return Result.Fail("Ваша ставка была перекрыта, пожалуйста, повторите попытку.");
        
        bets.Add(bet);
        return Result.Ok();
    }
}