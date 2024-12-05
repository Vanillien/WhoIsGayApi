using System.Security.Claims;
using System.Security.Principal;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Models.Classes;

/// <summary>
/// Это класс, который выдает объект пользователя, который пользуется клиентом. Иными словами, он как сканер отпечатка.
/// Хотя сейчас павильнее сказать, что это скорее класс для взаимодействия с пользователем. Регистрация, получение пользователя - вот это вот все.
/// </summary>

public class UserService : IUserService
{
    public IUser GetCurrentUser(ClaimsPrincipal principal)
    {
        var user = new User()
        {
            Id = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value,
            Username = principal.FindFirst("preferred_name")?.Value,
            Email = principal.FindFirst(ClaimTypes.Email)?.Value,
            Roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList()
        };

        return user;
    }

    public async Task RegisterUserAsync(IUser user)
    {
        throw new NotImplementedException();
    }
}