using System.Collections;
using System.Linq.Expressions;
using WhoIsGayApi.Interfaces;

namespace WhoIsGayApi.Classes;

public class Person : IPerson 
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public bool Gay { get; set; }
    public string Email { get; set; } = "";

}