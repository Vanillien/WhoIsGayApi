using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("api/wawa")]
[ApiController]
[Authorize]
public class AdminPanelController : ControllerBase
{
    //Контроллер, доступный только админу
}