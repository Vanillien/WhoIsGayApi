using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("api/login")]
[ApiController]
[Authorize]
public class LoginController(KeycloakClient keycloakClient)
    : ControllerBase
{
    private readonly KeycloakClient _keycloakClient = keycloakClient;
    
    public async Task<IActionResult> RegisterUserAsync()
    {
        //_keycloakClient.CreateUserAsync()
    }
    
    public async Task<IActionResult> AuthenticateUserAsync()
    {
        throw new NotImplementedException();
    }
}