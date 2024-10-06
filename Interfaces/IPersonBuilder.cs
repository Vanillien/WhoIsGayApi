namespace WhoIsGayApi.Interfaces;

public interface IPersonBuilder
{
    public void SetFirstName(string firstName);
    public void SetLastName(string lastName);
    public void SetGay(bool gay);
    public IPerson BuildPerson();
}