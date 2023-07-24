namespace Auction.Domain;

public class Auction
{
    public int Id { get; init; }
    public int AuthorId { get; private set; }
    public string? Name { get; private set; }
    public Dictionary<int, Lot> Lots { get; init; } = new();
    public DateTime DateStart { get; private set; }
    public bool IsCreation { get; private set; }

    private DateTime dateEnd;

    public DateTime DateEnd
    {
        get
        {
            var maxDate = Lots.Values.SelectMany(l => l.Bets).Max(b => b.DateTime);
            return dateEnd > maxDate ? dateEnd : maxDate;
        }
        private set => dateEnd = value;
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

    public Auction(string name, int authorId, DateTime dateStart, DateTime dateEnd)
    {
        Name = name;
        AuthorId = authorId;
        DateStart = dateStart;
        DateEnd = dateEnd;
        IsCreation = true;
    }

    public void UpdateName(string name) => Name = name;

    public void UpdateDateStart(DateTime dateTime) => DateStart = dateTime;
    
    public void UpdateDateEnd(DateTime dateTime) => DateEnd = dateTime;

    public void ChangeIsCreation() => IsCreation = !IsCreation;
}