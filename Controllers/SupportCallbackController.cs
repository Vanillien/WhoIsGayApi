using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;

namespace WhoIsGayApi.Controllers;

[Route("supportcallback")]
[ApiController]
[Authorize]
public class SupportCallbackController : ControllerBase
{
    //контроллер, доступный только админу
}