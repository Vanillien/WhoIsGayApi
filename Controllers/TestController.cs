using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Models.Classes;

namespace WhoIsGayApi.Controllers;

[ApiController]
[Route("api/test")]
[Authorize]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Gagabuga()
    {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "{Here null, oops!}";
        string userName = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? "{Here null, oops!}";
        string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value ?? "{Here null, oops!}";
        return new string($"ID этого овоща - {userId}. Его зовут {userName}. Его email {email}");
    }
}