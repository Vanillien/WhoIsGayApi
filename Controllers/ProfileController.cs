using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("api/profile")] 
[ApiController]
public class ProfileController(IUserService userService) : ControllerBase //навешать атрибутов надобно
{
    private readonly IUserService _userService = userService;
    
    [HttpGet]
    [Route("index")]
    [ProducesResponseType(200)]
    [Produces<User>]
    public async Task<IActionResult> Index() //Index - метод, который кажись используется для получения каких то данных сразу после захода пользователя на страницу.
    {
        var currentUser = _userService.GetCurrentUser(User);
        return Ok(currentUser); //return: 200 status code, currentUser
    }
}