namespace WhoIsGayApi.Interfaces;

public interface INode
{
    public void WriteObj(string firstName, string lastName, bool gay);
    
    public void GetObj(string firstName);

    public void RemoveObj();
}