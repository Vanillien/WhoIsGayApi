using System.Text.Json.Serialization;
using NuGet.Packaging.Signing;
using WhoIsGayApi.Interfaces;

namespace WhoIsGayApi.Models;

public class Order : IOrder
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = "";
    
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = "";
    
    [JsonPropertyName("gay")]
    public bool Gay { get; set; }

    [JsonPropertyName("orderer")] 
    public string Orderer { get; set; } = "";
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = "";

    [JsonPropertyName("creation_time")] 
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;

}