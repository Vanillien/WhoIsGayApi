using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;

namespace WhoIsGayApi.Controllers;
/// <summary>
/// Этот залупо-код я спиздил у джибути. Я не ебу, как работает и не ебу работает ли вообще.
/// Так что надо будет понять, как работает, что тут зачем и переписать это к хуям.
///
/// Ну оно и не работает. Залупа ебаная. Джибути опять хуйни сделал. Видимо придется хуярить отдельный web soket сервер. Заебись? Нет.
/// </summary>

[Route("support")]
[ApiController]
public class SupportController : ControllerBase
{
    /*private static readonly ConcurrentBag<WebSocket> _clients = new();
    
    [Route("ws")]
    [HttpGet]
    public async Task Get() 
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            _clients.Add(webSocket);
            await HandleWebSocketAsync(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private async Task HandleWebSocketAsync(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];

        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Text)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                //
                message = "wawawuwa";
                //
                Console.WriteLine($"Received: {message}");
                await BroadcastMessageAsync(message);
            }
            else if (result.MessageType == WebSocketMessageType.Close)
            {
                _clients.TryTake(out _);
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed", CancellationToken.None);
            }
        }
    }
    
    private async Task BroadcastMessageAsync(string message) //этот метод занимается рассылкой
    {
        var buffer = Encoding.UTF8.GetBytes(message);

        foreach (var client in _clients)
        {
            if (client.State == WebSocketState.Open)
            {
                await client.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }*/
    
}