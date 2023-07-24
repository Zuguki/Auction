using System.Text.Json.Serialization;
using FluentResults;
using MediatR;

namespace Auction.Application.Auctions.Cancel;

public record CancelAuctionCommand : IRequest<Result>
{
    [JsonPropertyName("auctionId")]
    public int AuctionId { get; init; }
}