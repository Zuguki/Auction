using Auction.Application.Auctions.Cancel;
using Auction.Application.Auctions.Create;
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

    [HttpDelete]
    public async Task<IActionResult> DeleteAuctionAsync([FromQuery] CancelAuctionCommand command,
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