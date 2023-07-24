using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult ConvertToActionResult(ResultBase result)
    {
        if (result.IsFailed)
            return BadRequest(string.Join(", ", result.Reasons.Select(r => r.Message)));
        
        return Ok();
    } 
}