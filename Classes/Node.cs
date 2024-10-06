using WhoIsGayApi.Interfaces;
using WhoIsGayApi.Classes;
using Microsoft.EntityFrameworkCore;

namespace WhoIsGayApi.Classes;

//Я хз, что такое Node и назвал этот класс так тупо по тому, что ему подходит сие наименование

public class Node : INode
{
    private IServiceProvider _serviceProvider;

    public Node(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void WriteObj(string firstName, string lastName, bool gay)
    {
        using (AppDbContext db = _serviceProvider.GetRequiredService<AppDbContext>())
        {
            var personBuilder = _serviceProvider.GetRequiredService<PersonBuilder>();
            personBuilder.SetFirstName(firstName);
            personBuilder.SetLastName(lastName);
            personBuilder.SetGay(gay);
            db.SaveChanges();
        }
    }
    
    public void GetObj(string firstName)
    {
        using (AppDbContext db = _serviceProvider.GetRequiredService<AppDbContext>())
        {
            //IQueryable<Person> res = db.Persons.Where(p => p.FirstName == firstName);
            //т.к. поиск должен происходить по любому из свойств, то делать перегрузку метода что ли? Под все возможные комбинации? Была какая то нормальная альтернатива вместо этого говна, но я забыл.
        }
    }

    public void RemoveObj()
    {
        
    }
}