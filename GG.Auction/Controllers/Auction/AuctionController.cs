using Auction.Controllers.Auction.Dto;
using FluentResults;
using GG.Auction.Application.Auctions.Cancel;
using GG.Auction.Application.Auctions.ChangeCreationAuction;
using GG.Auction.Application.Auctions.Create;
using GG.Auction.Application.Auctions.Delete;
using GG.Auction.Application.Auctions.Get;
using GG.Auction.Application.Auctions.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("api/v1/auctions")]
public class AuctionController : BaseController
{
    private readonly IMediator mediator;

    public AuctionController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuctionAsync(CreateAuctionCommand command,
        CancellationToken cancellationToken) =>
        ConvertToActionResult(await mediator.Send(command, cancellationToken));

    [HttpPost("cancel")]
    public async Task<IActionResult> CancelAuctionAsync(CancelAuctionCommand command,
        CancellationToken cancellationToken) =>
        ConvertToActionResult(await mediator.Send(command, cancellationToken));
    
    [HttpPost("changeCreationState")]
    public async Task<IActionResult> CompleteCreationAsync(ChangeAuctionCreationStateCommand command,
        CancellationToken cancellationToken) =>
        ConvertToActionResult(await mediator.Send(command, cancellationToken));
    
    [HttpDelete]
    public async Task<IActionResult> DeleteAuctionAsync([FromQuery] DeleteAuctionCommand command,
        CancellationToken cancellationToken) =>
        ConvertToActionResult(await mediator.Send(command, cancellationToken));

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateAuctionCommand command, CancellationToken cancellationToken) =>
        ConvertToActionResult(await mediator.Send(command, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAuctionsAsync([FromQuery] GetAuctionsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(query, cancellationToken);
        if (result.IsFailed)
            return BadRequest(string.Join(", ", result.Reasons.Select(r => r.Message)));

        var auctionDtos = result.Value.Select(a => new AuctionDto
        {
            Id = a.Id,
            Name = a.Name,
            Status = a.Status,
            DateStart = a.DateStart,
            DateEnd = a.DateEnd,
        });

        return Ok(auctionDtos);
    }
}