using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Models.Classes;

public class User : IUser
{
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string ImageUrl { get; set; } = "";
}