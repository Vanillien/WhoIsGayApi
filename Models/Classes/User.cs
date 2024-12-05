using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Models.Classes;

public class User : IUser
{
    public string? Id { get; set; } = ""; //вопросик делает так, что тип более не допускает значение null
    public string? Username { get; set; } = "";
    public string? Email { get; set; } = "";
    public List<string>? Roles { get; set; }
    
}