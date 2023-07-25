using System.Text.Json.Serialization;
using FluentResults;
using MediatR;

namespace GG.Auction.Application.Lots.Create;

public record CreateLotCommand : IRequest<Result>
{
    [JsonPropertyName("auctionId")]
    public Guid AuctionId { get; init; }
    
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("description")]
    public string? Description { get; init; }
    
    [JsonPropertyName("code")]
    public string? Code { get; init; }
    
    [JsonPropertyName("betStep")]
    public decimal BetStep { get; init; }
    
    [JsonPropertyName("buyoutPrice")]
    public decimal? BuyoutPrice { get; init; }
}