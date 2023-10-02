using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Policy = "IsAdmin")]
    public class AuthenticController : Controller
    {
        [HttpPost("/Auth/Logins")]
        public IActionResult Login(string login, string password)
        {
            return Ok();
        }
    }
}
