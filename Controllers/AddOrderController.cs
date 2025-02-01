using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;
using WhoIsGayApi.Models;

namespace WhoIsGayApi.Controllers;
/// <summary>
///Completed
/// </summary>
/// <param name="dbContextFactory"></param>

[Route("api/addorder")]
[ApiController]
[Authorize]
public class AddOrderController(IDbContextFactory<OrderContext> dbContextFactory)
    : ControllerBase
{
    [HttpGet]
    [Route("add")]
    public async Task AddOrderAsync(string firstName, string lastName, string description)
    {
        //Тут создается новый Order и отправляется в БД. Для записи поля Orderer будет получено имя пользователя и записано в это поле.
        await using var db = await dbContextFactory.CreateDbContextAsync();
        db.Add(new Order()
        {
            FirstName = firstName,
            LastName = lastName,
            Description = description,
            Orderer = HttpContext.User.FindFirst("preferred_username")?.Value ?? "null"
        });
        await db.SaveChangesAsync();
    }
}
