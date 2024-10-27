using System.Text.Json.Serialization;

namespace WhoIsGayApi.Models.Classes;

public class AllPersonsModel
{
    [JsonPropertyName("persons")]
    public List<Person> Persons { get; set; }
}