using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("support")]
[ApiController]
//[Authorize]
public class SupportController(WebSocketHandler webSocketHandler) : ControllerBase
{
    [HttpGet]
    [Route("ws")]
    public async Task Connect() // 
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await webSocketHandler.HandleConnection(webSocket, HttpContext);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}