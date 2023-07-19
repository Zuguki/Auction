namespace Auction.Domain;

public class Auction
{
    public int Id { get; init; }
    public int AuthorId { get; init; }
    public string? Name { get; init; }
    public Dictionary<int, Lot> Lots { get; init; } = new();
    public DateTime DateStart { get; init; }
    public bool IsCreation { get; init; }

    private DateTime dateEnd;

    public DateTime DateEnd
    {
        get
        {
            var maxDate = Lots.Values.SelectMany(l => l.Bets).Max(b => b.DateTime);
            return dateEnd > maxDate ? dateEnd : maxDate;
        }
        init => dateEnd = value;
    }

    public AuctionStatus Status
    {
        get
        {
            if (IsCreation)
                return AuctionStatus.Creation;
            
            var dateTimeNow = DateTime.UtcNow;
            if (dateTimeNow < DateStart)
                return AuctionStatus.WaitBidding;

            if (dateTimeNow > DateStart && dateTimeNow < DateEnd)
                return AuctionStatus.Bidding;
            
            return AuctionStatus.Complete;
        }
    }
}