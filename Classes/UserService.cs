using System.Security.Claims;
using System.Security.Principal;
using WhoIsGayApi.Interfaces;
using WhoIsGayApi.Models;


namespace WhoIsGayApi.Classes;

/// <summary>
/// Это класс, который выдает объект пользователя, который пользуется клиентом. Иными словами, он как сканер отпечатка.
/// Хотя сейчас павильнее сказать, что это скорее класс для взаимодействия с пользователем. Регистрация, получение пользователя - вот это вот все.
///
/// Сейчас уже корректней сказать, что это класс, который создает пользователя, как .net объект на основе principals
/// </summary>

public class UserService : IUserService
{
    public IUser GetUserOnId(string id)
    {
        // получить объект юзера через keycloak rest api по id и вернуть его
        throw new NotImplementedException();
    }
}