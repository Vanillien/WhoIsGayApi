using System.Text.Json.Serialization;
using Newtonsoft.Json;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Models.Classes;

public class Person : IPerson 
{
    public Person(IUser orderer)
    {
        Orderer = orderer;
    }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = "";
    
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = "";
    
    [JsonPropertyName("gay")]
    public bool Gay { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; } = "";
    
    [JsonPropertyName("orderer")]
    public IUser Orderer { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = "";

}