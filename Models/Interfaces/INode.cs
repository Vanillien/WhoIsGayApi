using WhoIsGayApi.Models.Classes;

namespace WhoIsGayApi.Models.Interfaces;

public interface INode
{
    //public void CreateWriteObj(string firstName, string lastName, bool gay, string email);

    public void WriteObj(Person person);
    
    public List<Person> GetObj(string name1, string name2);
    
    public List<Person> GetObj(string firstName);

    public void RemoveObj(List<Person> persons);
}