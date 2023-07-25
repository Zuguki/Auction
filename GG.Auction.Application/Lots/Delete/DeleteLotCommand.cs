using System.Text.Json.Serialization;
using FluentResults;
using MediatR;

namespace GG.Auction.Application.Lots.Delete;

public class DeleteLotCommand : IRequest<Result>
{
    [JsonPropertyName("auctionId")]
    public Guid AuctionId { get; init; }
    
    [JsonPropertyName("lotId")]
    public Guid LotId { get; init; }
}