using Microsoft.AspNetCore.Mvc;

namespace ChangeCreationStateAuctionCommand.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AuthAsync()
    {
        return Ok();
    }
}