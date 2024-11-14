using Microsoft.EntityFrameworkCore;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Models.Classes;

//Я хз, что такое Node и назвал этот класс так тупо по тому, что ему подходит сие наименование

public class Node(IDbContextFactory<AppDbContext> dbContextFactory) : INode
{
    public void CreateWriteObj(string firstName, string lastName, bool gay, string email)
    {
        using var db = dbContextFactory.CreateDbContext();
        
        var person = new Person() {FirstName = firstName, LastName = lastName, Gay = gay, Email = email};
        db.Persons.Add(person);
        db.SaveChanges();
    }

    public void WriteObj(Person person)
    {
        using var db = dbContextFactory.CreateDbContext();
        db.Persons.Add(person);
        db.SaveChanges();
    }
    
    public List<Person> GetObj(string firstName)
    {
        using var db = dbContextFactory.CreateDbContext();
        var persons = db.Persons
            .Where(p => p.FirstName == firstName)
            .ToList();
        return persons;
    }

    public List<Person> GetObj(string name1, string name2)
    {
        using var db = dbContextFactory.CreateDbContext();

        var persons = db.Persons
            .Where(p => p.FirstName == name1)
            .Where(p => p.FirstName == name2)
            .Where(p => p.LastName == name1)
            .Where(p => p.LastName == name2)
            .ToList();
        
        return persons;
    }

    public void RemoveObj(List<Person> persons)
    {
        using var db = dbContextFactory.CreateDbContext();
        db.Persons.RemoveRange(persons);
        db.SaveChanges();
    }
}