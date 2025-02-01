using System.Text.Json.Serialization;

namespace WhoIsGayApi.Models;
/// <summary>
///Этот класс нужен для того, чтобы просто хранить несколько объектов в себе
/// </summary>
public class AllOrdersModel
{
    [JsonPropertyName("persons")]
    public List<Order>? Orders { get; set; }
    
}