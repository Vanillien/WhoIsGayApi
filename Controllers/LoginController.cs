
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("api/login")]
[ApiController]
[Authorize]
public class LoginController(KeycloakClient keycloakClient, KeycloakTokenService tokenService)
    : ControllerBase
{
    
    [Route("register")]
    [HttpGet]
    [ProducesResponseType(200)]
    [Produces("application/json")]
    public async Task<IActionResult> RegisterUserAsync()//UserKeycloakDto // User user
    {
        var adminToken = await tokenService.GetAccessTokenAsync();
        
        /*var user = new User() 
        {
            Id = "b2c2ec6b-b3d7-46f4-ba5e-a7dab46231f8",
            Username = "Googendochen",
            Email = "bublik665@gmail.com"
        };
        ///
        await keycloakClient.CreateUserAsync(user);*/
        Console.WriteLine($"ВОТ ТОКЕН: {adminToken}");
        return Ok(adminToken);//смысл в этом методе, если он срабатывает вне зависимости от того, как .CreateUserAsync() сработает
    }
    
    /*public async Task<IActionResult> AuthenticateUserAsync()
    {
        throw new NotImplementedException();
    }*/
}