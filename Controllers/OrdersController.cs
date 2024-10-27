using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Http;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("orders")]
[ApiController]
public class OrdersController(INode node) : ControllerBase
{
    [Route("getorderedpersons")]
    [HttpGet]
    [Produces<AllPersonsModel>]
    [ProducesResponseType(200)]
    public IActionResult GetOrderedPersons()
    {
        throw new Exception(); //Найти в базе данных тех Persons, у которых свойство Orderer - это User, использующий метод
    }
}