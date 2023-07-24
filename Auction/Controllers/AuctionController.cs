using Auction.Application.Auctions.Cancel;
using Auction.Application.Auctions.Create;
using Auction.Application.Auctions.ChangeCreationAuction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChangeCreationStateAuctionCommand.Controllers;

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

    [HttpPut]
    public async Task<IActionResult> UpdateAsync()
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAuctionsAsync()
    {
        return Ok();
    }
}