using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("adminpanel")]
[ApiController]
[Authorize]
public class AdminPanelController : ControllerBase
{
    //Контроллер, доступный только админу
}