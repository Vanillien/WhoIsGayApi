using WhoIsGayApi.Interfaces;
using WhoIsGayApi.Classes;
using Microsoft.EntityFrameworkCore;

namespace WhoIsGayApi.Classes;

//Я хз, что такое Node и назвал этот класс так тупо по тому, что ему подходит сие наименование

public class Node : INode
{
    //private IServiceProvider _serviceProvider;
    private IDbContextFactory<AppDbContext> _dbContextFactory;
    
    public Node(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public void WriteObj(string firstName, string lastName, bool gay)
    {
        using (AppDbContext db = _dbContextFactory.CreateDbContext())
        {
            var person = new Person() {FirstName = firstName, LastName = lastName, Gay = gay};
            db.Persons.Add(person);
            db.SaveChanges();
        }
    }
    
    public List<Person> GetObj(string firstName)
    {
        using (AppDbContext db = _dbContextFactory.CreateDbContext())
        {
            var persons = db.Persons
                .Where(p => p.FirstName == firstName)
                .ToList();
            return persons;
        }
    }

    public void RemoveObj()
    {
        
    }
}