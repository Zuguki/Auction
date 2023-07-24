using System.Text.Json.Serialization;
using FluentResults;
using MediatR;

namespace GG.Auction.Application.Auctions.Update;

public record UpdateAuctionCommand : IBaseRequest, IRequest<Result>
{
    [JsonPropertyName("auctionId")]
    public int AuctionId { get; init; }
    
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("dateStart")]
    public DateTime DateStart { get; init; }
    
    [JsonPropertyName("dateEnd")]
    public DateTime DateEnd { get; init; }
}