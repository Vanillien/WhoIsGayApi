using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Http;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;
using WhoIsGayApi.Models;

namespace WhoIsGayApi.Controllers;
/// <summary>
///Completed
/// </summary>
[Route("orders")]
[ApiController]
public class OrdersController(IDbContextFactory<OrderContext> dbContextFactory) : ControllerBase
{
    [Route("index")]
    [HttpGet]
    [Produces<AllOrdersModel>]
    [ProducesResponseType(200)]
    public async Task<AllOrdersModel> Index()
    {
        var username = HttpContext.User.FindFirst("preferred_username")?.Value ?? "null";
        await using var db = await dbContextFactory.CreateDbContextAsync();
        AllOrdersModel orders = new AllOrdersModel();
        orders.Orders = await db.Orders.Where(o => o.Orderer == username).ToListAsync();
        return orders;
    }
}