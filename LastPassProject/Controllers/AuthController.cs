using LastPassProject.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LastPassProject
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("signin-google")]
        public async Task<ActionResult> Google()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = "/vault"
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
    }
}
