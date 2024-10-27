namespace WhoIsGayApi.Models.Interfaces;

public interface IUser
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string ImageUrl { get; set; }
}