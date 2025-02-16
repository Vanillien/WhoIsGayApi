using System.Text.Json.Serialization;

namespace WhoIsGayApi.Models;

public class Message
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("text")] 
    public string Text { get; set; } = "";

    [JsonPropertyName("user")] 
    public string? User { get; set; } = "";
    
    [JsonPropertyName("time")]
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;
}