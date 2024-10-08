using WhoIsGayApi.Classes;

namespace WhoIsGayApi.Interfaces;

public interface INode
{
    public void CreateWriteObj(string firstName, string lastName, bool gay, string email);

    public void WriteObj(Person person);
    
    public List<Person> GetObj(string firstName);

    public void RemoveObj();
}