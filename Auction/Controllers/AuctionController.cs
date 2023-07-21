using Auction.Application.Auctions.CreateAuction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("api/v1/auctions")]
public class AuctionController : ControllerBase
{
    private readonly IMediator mediator;

    public AuctionController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuctionAsync(CreateAuctionCommand command, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(command, cancellationToken);
        if (response.IsFailed)
            return BadRequest(string.Join(',', response.Reasons.Select(r => r.Message)));
        
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAuctionAsync()
    {
        return Ok();
    }

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