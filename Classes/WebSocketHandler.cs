using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using WhoIsGayApi.Models;

namespace WhoIsGayApi.Classes;

public class WebSocketHandler(IDbContextFactory<MessagesContext> messageContextFactory)
{
    private static readonly ConcurrentDictionary<Guid, WebSocket> Сlients = new(); //Hash-table //Каждое подключение веб сокета хранится по id
    
    public async Task HandleConnection(HttpContext context, WebSocket webSocket)
    {
        
        var token = context.Request.Query["token"];//обработка токена
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        var username = jwt.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
        //// remove in prod
        Console.WriteLine($"Подключился: {username}");
        //// remove in prod
        var clientId = Guid.NewGuid(); //создание уникального id
        Сlients[clientId] = webSocket; //добавляем подключение в хэш таблицу

        try //пробуем принять соединение
        {
            await ReceiveMessages(webSocket, username);
        }
        finally
        {
            Сlients.TryRemove(clientId, out _);
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed", CancellationToken.None); //закрытие подключения
        }
    }

    private async Task ReceiveMessages(WebSocket webSocket, string? username) //получает сообщение и записывает его в буфер, а потом переводит байты сообщения в строковое сообщение и вызывая BroadcastMessage() рассылает сообщение всем, кто подключен.
    {
        var buffer = new byte[1024 * 4]; //Я что то даже и забыл, что память то выделяется не какая нибудь нематериальная, а самая настоящая. Я выделил 4кб на буфер.
        //var username = httpContext.User.FindFirst("preferred_username")?.Value ?? "gagabuga";
        
        while (webSocket.State == WebSocketState.Open) 
        {
            var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None); //записывает сообщение в буфер, как байты. ReceiveAsync принимает только ArraySegment<T>

            var message = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count); //переводит байты в строку
            //buffer - массив байтов, который декодируется. index - индекс, с которого начинается чтение. receiveResult.Count - кол-во байтов, которые нужно декодировать
            
            //Тут должно быть сохранение сообщений в бд
            await using var messageContext = await messageContextFactory.CreateDbContextAsync();
            await messageContext.Messages.AddAsync(new Message()
            {
                Text = message,
                User = username
            });
            await messageContext.SaveChangesAsync();

            await BroadcastMessage($"{username}: {message}"); //clientId нужен для того, чтобы вообще понимать, кто отправляет сообщение. 
        }
        
    }
    
    private async Task BroadcastMessage(string message) //Этот метод рассылает сообщение всем.
    {
        var bytes = Encoding.UTF8.GetBytes(message); //энкодинг сообщения в байты
        
        var buffer = new ArraySegment<byte>(bytes); //Создание буфера

        foreach (var client in Сlients.Values) //перебор всех подключений и отправка сообщения только тем, у кого открыт веб сокет
        {
            if (client.State == WebSocketState.Open)
            {
                await client.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None); //отправка сообщения в веб сокет 
            }
        }
    }
    
    /*
    private void ReleaseUnmanagedResources() //В этом методе нужно вручную освободить каждый ресурс, который используется в классе
    {
        if (unmanagedResource != какое то ничего)
        {
            отпускаем на свободу(убиваем)
        }
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~WebSocketHandler() //deconstructor
    {
        ReleaseUnmanagedResources();
    }*/
}