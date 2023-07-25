using System.Text.Json.Serialization;
using GG.Auction.Domain;

namespace Auction.Controllers.Auction.Dto;

public record AuctionDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
    
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("dateStart")]
    public DateTime DateStart { get; init; }
    
    [JsonPropertyName("dateEnd")]
    public DateTime DateEnd { get; init; }
    
    [JsonPropertyName("status")]
    public AuctionStatus Status { get; init; }
}