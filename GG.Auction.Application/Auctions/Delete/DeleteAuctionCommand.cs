using System.Text.Json.Serialization;
using FluentResults;
using MediatR;

namespace GG.Auction.Application.Auctions.Delete;

public record DeleteAuctionCommand : IRequest<Result>
{
    [JsonPropertyName("auctionId")]
    public Guid AuctionId { get; init; }
}