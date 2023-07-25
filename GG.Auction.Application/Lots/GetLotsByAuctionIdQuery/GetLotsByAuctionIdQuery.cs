using System.Text.Json.Serialization;
using FluentResults;
using GG.Auction.Domain;
using MediatR;

namespace GG.Auction.Application.Lots.GetLotsByAuctionIdQuery;

public record GetLotsByAuctionIdQuery : IRequest<Result<IEnumerable<Lot>>>
{
    [JsonPropertyName("auctionId")]
    public Guid AuctionId { get; init; }
}