using System.Text.Json.Serialization;
using FluentResults;
using MediatR;

namespace GG.Auction.Application.Bets.DoBet;

public record DoBetCommand : IRequest<Result>
{
    [JsonPropertyName("lotId")]
    public Guid LotId { get; init; }

    /// <summary>
    /// Идентификатор аукциона
    /// </summary>
    [JsonPropertyName("auctionId")]
    public Guid AuctionId { get; set; }
}