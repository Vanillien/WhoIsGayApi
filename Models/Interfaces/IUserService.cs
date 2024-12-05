using System.Security.Claims;
using k8s.KubeConfigModels;
using WhoIsGayApi.Models.Classes;
using User = k8s.KubeConfigModels.User;

namespace WhoIsGayApi.Models.Interfaces;

public interface IUserService
{
    public IUser GetCurrentUser(ClaimsPrincipal principal);

    public Task RegisterUserAsync(IUser user);
}