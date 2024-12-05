using System.Runtime.InteropServices.JavaScript;
using NuGet.Packaging.Signing;

namespace WhoIsGayApi.Models.Interfaces;

public interface IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Gay { get; set; }
    public IUser Orderer { get; set; }
    public string Description { get; set; }
    public DateTime CreationTime { get; set; }
}