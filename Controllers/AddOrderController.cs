using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("api/addorder")]
[ApiController]
[Authorize]
public class AddOrderController(IUserService userService, IDbContextFactory<PersonContext> dbContextFactory)
    : ControllerBase
{
    [HttpPost]
    [Route("addorderasync")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> AddOrderAsync(string firstName, string lastName, bool gay, string description)
    {
        await using var db = await dbContextFactory.CreateDbContextAsync();
        var person = new Person(userService.GetCurrentUser(User))
        {
            FirstName = firstName,
            LastName = lastName,
            Gay = gay,
            Description = description,
            CreationTime = DateTime.UtcNow
        };
        await db.Persons.AddAsync(person);
        await db.SaveChangesAsync();
        return Ok(); //return: 200 status code
    }
}
