using WhoIsGayApi.Interfaces;

namespace WhoIsGayApi.Classes;

public class PersonBuilder : IPersonBuilder
{
    private readonly IPerson _person;

    public PersonBuilder(IPerson person)
    {
        _person = person;
    }

    public void SetFirstName(string firstName)
    {
        _person.FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        _person.LastName = lastName;
    }

    public void SetGay(bool gay)
    {
        _person.Gay = gay;
    }

    public void SetEmail(string email)
    {
        _person.Email = email;
    }

    public IPerson BuildPerson()
    {
        IPerson person = _person;
        return person;
    }
}