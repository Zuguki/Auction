using GG.Auction.Application.Lots.Create;
using GG.Auction.Application.Lots.Delete;
using GG.Auction.Application.Lots.GetLotsByAuctionIdQuery;
using GG.Auction.Application.Lots.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers.Lot;

[ApiController]
[Route("api/v1/auctions/lots")]
public class LotsController : BaseController
{
    private readonly IMediator mediator;

    public LotsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLotAsync(CreateLotCommand command, CancellationToken cancellationToken) =>
        ConvertToActionResult(await mediator.Send(command, cancellationToken));

    [HttpDelete]
    public async Task<IActionResult> DeleteLotAsync(DeleteLotCommand command, CancellationToken cancellationToken) =>
        ConvertToActionResult(await mediator.Send(command, cancellationToken));

    [HttpPut]
    public async Task<IActionResult> UpdateLotAsync(UpdateLotCommand command, CancellationToken cancellationToken) =>
        ConvertToActionResult(await mediator.Send(command, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetLotsByAuctionIdAsync([FromQuery] GetLotsByAuctionIdQuery query,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(query, cancellationToken);
        if (result.IsFailed)
            return BadRequest(string.Join(", ", result.Reasons.Select(r => r.Message)));

        return Ok(result.Value);
    }
}