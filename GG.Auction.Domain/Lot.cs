using FluentResults;

namespace GG.Auction.Domain;

public class Lot
{
    public Guid Id { get; init; }
    
    public string Name { get; private set; }
    
    public string Code { get; private set; }
    
    public string Description { get; private set; }

    public decimal BetStep { get; private set; }
    
    public decimal? BuyoutPrice { get; private set; }
    
    private readonly List<Bet> _bets = new List<Bet>();

    public IReadOnlyCollection<Bet> Bets => _bets;

    public IReadOnlyCollection<string> Images { get; init; }

    public bool IsPurchased => _bets.Count > 0 && _bets.Max(b => b.Amount) == BuyoutPrice;
    
    public Lot(string name, string code, string description, decimal betStep, decimal? buyoutPrice = null, params string[] images)
    {
        Id = Guid.NewGuid();
        Name = name;
        Code = code;
        Description = description;
        BetStep = betStep;
        BuyoutPrice = buyoutPrice;
        Images = images;
    }

    public Result<Bet> TryDoBet(Guid userId)
    {
        if (IsPurchased)
            return Result.Fail("По данному лоту запрещено делать ставки, т.к. он выкуплен");

        var nextStep = _bets.Count > 0
            ? _bets.Max(b => b.Amount) + BetStep
            : BetStep;
        
        var bet = new Bet
        {
            Id = Guid.NewGuid(),
            LotId = Id,
            Amount = nextStep,
            AuthorId = userId,
            DateTime = DateTime.UtcNow
        };
        
        _bets.Add(bet);
        
        return Result.Ok(bet);
    }

    /// <summary>
    /// Обновление информации по лоту
    /// </summary>
    /// <param name="name">Название лота</param>
    /// <param name="code">Код лота</param>
    /// <param name="description">Описание лота</param>
    /// <param name="betStep">Шаг ставки</param>
    /// <param name="buyoutPrice">Стоимость выкупа</param>
    /// <returns>Результат обновления информации. Если лот уже выкуплен, то вернется Fail</returns>
    public Result UpdateInformation(string name, string code, string description, decimal betStep, decimal? buyoutPrice)
    {
        if (IsPurchased)
            return Result.Fail("По данному лоту запрещено делать ставки, т.к. он выкуплен");
        
        Name = name;
        Code = code;
        Description = description;
        BetStep = betStep;
        BuyoutPrice = buyoutPrice;
        
        return Result.Ok();
    }
}