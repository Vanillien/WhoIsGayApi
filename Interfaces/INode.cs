using WhoIsGayApi.Classes;

namespace WhoIsGayApi.Interfaces;

public interface INode
{
    public void WriteObj(string firstName, string lastName, bool gay);
    
    public List<Person> GetObj(string firstName);

    public void RemoveObj();
}