using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
[Route("api/v1/auction")]
public class AuctionController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAuctionAsync()
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAuctionAsync()
    {
        return Ok();
    }
    
    [HttpPut]
    public a
}