using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;
using WhoIsGayApi.Models;

namespace WhoIsGayApi.Controllers; 
/// <summary>
/// Completed
/// </summary>

[Route("api/profile")] 
[ApiController]
[Authorize]
public class ProfileController : ControllerBase 
{
    [HttpGet]
    [Route("index")]
    [ProducesResponseType(200)]
    public async Task<JsonResult> Index() //Index - метод, который кажись используется для получения каких то данных сразу после захода пользователя на страницу.
    {
        var result = new
        {
            username = HttpContext.User.FindFirst("name")?.Value,
            email = HttpContext.User.FindFirst("email")?.Value,
            preferredName = HttpContext.User.FindFirst("preferred_username")?.Value
        };

        return new JsonResult(result);
    }
}