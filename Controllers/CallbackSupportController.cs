using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("api/wawa")]
[ApiController]
[Authorize(Roles = "admin")]
public class CallbackSupportController : ControllerBase
{
    //контроллер, доступный только админу
}