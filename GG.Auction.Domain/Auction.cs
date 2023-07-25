using FluentResults;

namespace GG.Auction.Domain;

public class Auction
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid AuthorId { get; private set; }
    public string? Name { get; private set; }
    public Dictionary<Guid, Lot> Lots { get; init; } = new();
    public DateTime DateStart { get; private set; }
    public bool IsCreation { get; private set; }
    public bool IsCanceled { get; private set; }

    private DateTime dateEnd;

    public DateTime DateEnd
    {
        get
        {
            if (Lots.Count == 0)
                return dateEnd;
            
            var maxDate = Lots.Values.SelectMany(l => l.Bets).Max(b => b.DateTime);
            return dateEnd > maxDate ? dateEnd : maxDate;
        }
        private set => dateEnd = value;
    }

    public AuctionStatus Status
    {
        get
        {
            if (IsCanceled)
                return AuctionStatus.Cancel;
            
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

    public bool IsEditable => Status is not (AuctionStatus.Bidding or AuctionStatus.Complete or AuctionStatus.Cancel);

    public Auction(string name, Guid authorId, DateTime dateStart, DateTime dateEnd)
    {
        Name = name;
        AuthorId = authorId;
        DateStart = dateStart;
        DateEnd = dateEnd;
        IsCreation = true;
    }
    
    public Result<Lot> AddLot(string name, string code, string description, decimal betStep, decimal? buyoutPrice)
    {
        if (!IsEditable)
            return Result.Fail("Данный аукцион нельзя редактировать");

        var lot = new Lot(name, code, description, betStep, buyoutPrice);
        Lots.Add(lot.Id, lot);
        
        return Result.Ok(lot);
    }

    public void UpdateName(string name) => Name = name;

    public void UpdateDateStart(DateTime dateTime) => DateStart = dateTime;
    
    public void UpdateDateEnd(DateTime dateTime) => DateEnd = dateTime;

    public void ChangeCreationState() => IsCreation = !IsCreation;

    public void Cancel() => IsCanceled = true;
}