using System.Collections.Immutable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Controllers
{
    [Route("api/home")] 
    [ApiController]
    public class HomeController(INode node) : ControllerBase
    {
        
        [Route("getperson")]
        [HttpGet]
        [ProducesResponseType(200)]
        [Produces<Person>]
        public IActionResult GetPerson(string firstName)
        {
            var person = node.GetObj(firstName);
            
            return Ok(person);
        }
        
        public IActionResult FindPerson(string name1, string name2)
        {
            throw new Exception();
        }
    }
}
