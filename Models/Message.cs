using System.Text.Json.Serialization;

namespace WhoIsGayApi.Models;

public class Message
{
    [JsonPropertyName("text")] 
    public string Text { get; set; } = "";

    [JsonPropertyName("user")] 
    public string? User { get; set; } = "";
    
    [JsonPropertyName("time")]
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;
}