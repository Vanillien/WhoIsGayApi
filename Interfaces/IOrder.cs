using System.Runtime.InteropServices.JavaScript;
using NuGet.Packaging.Signing;

namespace WhoIsGayApi.Interfaces;

public interface IOrder
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Gay { get; set; }
    public string Orderer { get; set; }
    public string Description { get; set; }
    public DateTime CreationTime { get; set; }
}