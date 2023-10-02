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
        // Test endpoint for checking Authorize Attribute
        [HttpPost("/Auth/Logins")]
        public IActionResult LoginTest(string login, string password)
        {
            return Ok();
        }
    }
}
