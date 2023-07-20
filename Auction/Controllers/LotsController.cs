using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("api/v1/auctions/lots")]
public class LotsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLotAsync()
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLotAsync()
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLotAsync()
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetLotsByAuctionIdAsync([FromQuery] int auctionId)
    {
        return Ok();
    }
}