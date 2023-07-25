using System.Text.Json.Serialization;
using FluentResults;
using MediatR;

namespace GG.Auction.Application.Auctions.Get;

public record GetAuctionsQuery : IRequest<Result<IEnumerable<Domain.Auction>>>
{
    [JsonPropertyName("lastAuctionId")]
    public int? LastAuctionId { get; init; }
}