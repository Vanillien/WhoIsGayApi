using System.Collections.Immutable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Controllers
{
    /// <summary>
    /// Этот контроллер является поисковой строкой. (еще не доделано)
    /// </summary>
    [Route("api/home")] 
    [ApiController]
    public class HomeController(IDbContextFactory<PersonContext> dbContextFactory) : ControllerBase 
    {
        [Route("getperson")]
        [HttpGet]
        [ProducesResponseType(200)]
        [Produces<Person>]
        public async Task<IActionResult> GetPersonAsync(string firstName)
        {
            await using var db = await dbContextFactory.CreateDbContextAsync();
            var person = await db.Persons.FindAsync(firstName); 
            
            return Ok(person); 
        }
        
    }
}
