using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;

namespace WhoIsGayApi.Classes;

static class WebSocketHandler
{
    private static readonly ConcurrentDictionary<Guid, WebSocket> Сlients = new(); //Hash-table //Каждое подключение веб сокета хранится по id
    
    public static async Task HandleConnection(WebSocket webSocket) //ПРОЧИТАЙ ЭТОТ БЛОК КОДА
    {
        var clientId = Guid.NewGuid(); //создание уникального id
        Сlients[clientId] = webSocket; //добавляем подключение в хэш таблицу

        try //пробуем принять соединение
        {
            await ReceiveMessages(webSocket, clientId);
        }
        finally
        {
            Сlients.TryRemove(clientId, out _);
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed", CancellationToken.None); //закрытие подключения
        }
    }

    private static async Task ReceiveMessages(WebSocket webSocket, Guid clientId) //получает сообщение и записывает его в буфер, а потом переводит байты сообщения в строковое сообщение и вызывая BroadcastMessage() рассылает сообщение всем, кто подключен.
    {
        var buffer = new byte[1024 * 4]; //Я что то даже и забыл, что память то выделяется не какая нибудь нематериальная, а самая настоящая. Я выделил 4кб на буфер. 

        while (webSocket.State == WebSocketState.Open) 
        {
            var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None); //записывает сообщение в буфер, как байты. ReceiveAsync принимает только ArraySegment<T>

            var message = Encoding.UTF8.GetString(buffer, 0, receiveResult.Count); //переводит байты в строку
            //buffer - массив байтов, который декодируется. index - индекс, с которого начинается чтение. receiveResult.Count - кол-во байтов, которые нужно декодировать

            await BroadcastMessage($"{clientId}: {message}"); //clientId нужен для того, чтобы вообще понимать, кто отправляет сообщение. 
        }
        
    }
    
    private static async Task BroadcastMessage(string message) //Этот метод рассылает сообщение всем.
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
}