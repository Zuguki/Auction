using System.Text.Json.Serialization;
using FluentResults;
using MediatR;

namespace Auction.Application.Auctions.ChangeCreationAuction;

public record ChangeAuctionCreationStateCommand : IRequest<Result>
{
    [JsonPropertyName("auctionId")]
    public int AuctionId { get; init; }
}