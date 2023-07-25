using GG.Auction.Application.Bets.DoBet;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers.Bet;

[ApiController]
[Route("api/v1/auctions/lots/bets")]
public class BetsController : BaseController
{
    private readonly IMediator mediator;

    public BetsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> DoBetAsync(DoBetCommand command, CancellationToken cancellationToken) =>
        ConvertToActionResult(await mediator.Send(command, cancellationToken));
}