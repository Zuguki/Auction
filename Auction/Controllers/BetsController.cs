using Microsoft.AspNetCore.Mvc;

namespace ChangeCreationStateAuctionCommand.Controllers;

[ApiController]
[Route("api/v1/auctions/lots/bets")]
public class BetsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> DoBetAsync()
    {
        return Ok();
    }
}