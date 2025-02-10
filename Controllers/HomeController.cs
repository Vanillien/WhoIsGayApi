using System.Collections.Immutable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;
using WhoIsGayApi.Models;
using System.Text.RegularExpressions;

namespace WhoIsGayApi.Controllers
{
    /// <summary>
    /// Completed
    /// </summary>
    [Route("home")] 
    [ApiController]
    public class HomeController(IDbContextFactory<OrderContext> dbContextFactory) : ControllerBase 
    {
        [Route("getorder")]
        [HttpGet]
        [ProducesResponseType(200)]
        [Produces<AllOrdersModel>]
        public async Task<AllOrdersModel> GetOrderAsync(string firstNameAndLastName)
        {
            await using var db = await dbContextFactory.CreateDbContextAsync();
            
            var orders = new AllOrdersModel
            {
                Orders = new List<Order>()
            };

            try
            {
                var name = Regex.Split(firstNameAndLastName, @"(?=[A-Z])"); 

                var ordersArray3 = await db.Orders
                    .Where(o => o.FirstName == name[2] && o.LastName == name[1])
                    .ToListAsync();
                var ordersArray4 = await db.Orders
                    .Where(o => o.FirstName == name[1] && o.LastName == name[2])
                    .ToListAsync();
                
                orders.Orders?.AddRange(ordersArray3);
                orders.Orders?.AddRange(ordersArray4);
            }
            catch
            {
                try
                {
                    var name = Regex.Split(firstNameAndLastName, @"(?=[А-Я])");
                
                    var ordersArray3 = await db.Orders
                        .Where(o => o.FirstName == name[2] && o.LastName == name[1])
                        .ToListAsync();
                    var ordersArray4 = await db.Orders
                        .Where(o => o.FirstName == name[1] && o.LastName == name[2])
                        .ToListAsync();
                
                    orders.Orders?.AddRange(ordersArray3);
                    orders.Orders?.AddRange(ordersArray4);
                }
                catch
                {
                    try
                    {
                        var firstName1 = firstNameAndLastName.Split(' ')[0];
                        var firstName2 = firstNameAndLastName.Split(' ')[1];
                        var lastName1 = firstNameAndLastName.Split(' ')[1];
                        var lastName2 = firstNameAndLastName.Split(' ')[0];

                        var ordersArray1 = await db.Orders
                            .Where(o => o.FirstName == firstName1 && o.LastName == lastName1)
                            .ToListAsync();
                        var ordersArray2 = await db.Orders
                            .Where(o => o.FirstName == firstName2 && o.LastName == lastName2)
                            .ToListAsync();

                        orders.Orders?.AddRange(ordersArray1);
                        orders.Orders?.AddRange(ordersArray2);
                    }
                    catch
                    {
                        Console.WriteLine();
                    }
                }
            }
            
            return orders;
        }
    }
}
