using System.Text.Json.Serialization;
using FluentResults;
using MediatR;

namespace GG.Auction.Application.Auctions.Create;

public record CreateAuctionCommand : IRequest<Result>
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("dateStart")]
    public DateTime DateStart { get; init; }
    
    [JsonPropertyName("dateEnd")]
    public DateTime DateEnd { get; init; }
}