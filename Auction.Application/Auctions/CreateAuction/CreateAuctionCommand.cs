using System.Text.Json.Serialization;
using FluentResults;
using MediatR;

namespace Auction.Application.Auctions.CreateAuction;

public record CreateAuctionCommand : IRequest<ResultBase>
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("dateStart")]
    public DateTime DateStart { get; init; }
    
    [JsonPropertyName("dateEnd")]
    public DateTime DateEnd { get; init; }
}