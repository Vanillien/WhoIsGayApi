using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Http;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Controllers;
/// <summary>
///  Тут можно посмотреть оставленные собой заказы и их текущее состояние. (не доделано)
/// </summary>
[Route("orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    [Route("getorderedpersons")]
    [HttpGet]
    [Produces<AllPersonsModel>]
    [ProducesResponseType(200)]
    public IActionResult GetOrderedPersonsAsync()
    {
        throw new Exception(); //Найти в базе данных тех Persons, у которых свойство Orderer - это User, использующий метод
    }
}