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
    /// Этот контроллер является поисковой строкой. (еще не доделано)
    /// </summary>
    [Route("api/home")] 
    [ApiController]
    public class HomeController(IDbContextFactory<OrderContext> dbContextFactory) : ControllerBase 
    {
        [Route("getperson")]
        [HttpGet]
        [ProducesResponseType(200)]
        [Produces<AllOrdersModel>]
        public async Task<AllOrdersModel> GetPersonAsync(string firstNameAndLastName)
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
                Console.WriteLine();
            }
            
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
                Console.WriteLine();
            }

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
            
            /*var firstName1 = firstNameAndLastName.Split(' ')[0];
            var firstName2 = firstNameAndLastName.Split(' ')[1];
            var lastName1 = firstNameAndLastName.Split(' ')[1];
            var lastName2 = firstNameAndLastName.Split(' ')[0];*/

            //var name = Regex.Split(firstNameAndLastName, @"(?=[A-Z])");//@"(?=[А-Я])
            
            /*var ordersArray1 = await db.Orders
                .Where(o => o.FirstName == firstName1 && o.LastName == lastName1)
                .ToListAsync();
            var ordersArray2 = await db.Orders
                .Where(o => o.FirstName == firstName2 && o.LastName == lastName2)
                .ToListAsync();*/
            /*var ordersArray3 = await db.Orders
                .Where(o => o.FirstName == name[2] && o.LastName == name[1])
                .ToListAsync();
            var ordersArray4 = await db.Orders
                .Where(o => o.FirstName == name[1] && o.LastName == name[2])
                .ToListAsync();*/
            
            /*var orders = new AllOrdersModel
            {
                Orders = new List<Order>()
            };*/
            
            //Надо ебануть сюда проверочек и вариативности.
            
            /*orders.Orders?.AddRange(ordersArray1);
            orders.Orders?.AddRange(ordersArray2);
            orders.Orders?.AddRange(ordersArray3);
            orders.Orders?.AddRange(ordersArray4);*/
            return orders;
            //Для начала скажу, что делятся стоки неправильно. И по итогу у меня появляется массив из 4 элементов. Нужно пофиксить деление и т.к. оно возвращает массив, то надо получать этот массив в 1 переменную, а не в 4, как ебнутый.
            //УЖЕ ДВАЖДЫ БЛЯТЬ МНЕ ЕБУЧИЙ ДЖИБУТИ ПОДСУНУЛ ХУЙНЮ. Мне надо просто разделить строку особым способом, а джибути говорит в 1 раз одну хуйню, а во второй другую. И они обе не работают и вызывают ошибки. 
            //Пиздаблядскими костылями оно как то работает. Одна проблема. Делает оно это только с английским алфавитом. Надо с русским добавить. Но я так и так уже затрахался. Так что пойду спать нахуй.
        }
    }
}
