using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace WhoIsGayApi.Controllers;

[Route("support")]
[ApiController]
//[Authorize] //этот атрибут требует auth токен
public class SupportController(WebSocketHandler webSocketHandler) : ControllerBase
{
    [HttpGet]
    [Route("ws")]
    public async Task Connect() 
    {
        
        //Валидация токена перед установкой соединения
        
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            var username = Test();
            await webSocketHandler.HandleConnection(HttpContext, webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    
    [HttpGet]
    [Route("test")]
    public string Test()
    {
        var wawa = HttpContext.User.FindFirst("preferred_username")?.Value ?? "wawa";
        return wawa;
    }
}