using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("api/wawa")]
[ApiController]
[Authorize]
public class AdminPanelController : ControllerBase
{
    //Контроллер, доступный только админу
}