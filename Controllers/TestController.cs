using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Classes;

namespace WhoIsGayApi.Controllers;
/// <summary>
/// Completed*
/// </summary>

[ApiController]
[Route("api/test")]
[Authorize]
public class TestController : ControllerBase
{
    [HttpGet]
    [Route("gagabuga")]
    public string Gagabuga()
    {
        var claims = HttpContext.User.Claims;
        
        foreach (var claim in claims)
        {
            Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
        }
        
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "{Here null, oops!";
        var userName = HttpContext.User.FindFirst("name")?.Value ?? "{Here null, oops!}";
        var email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value ?? "{Here null, oops!}";
        return new string($"ID этого овоща - {userId}. Его зовут {userName}. Его email {email}");
    }
}