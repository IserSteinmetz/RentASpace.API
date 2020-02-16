using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentASpace.API.Controllers
{
    
    [ApiController]
    [Route("Test")]
    public class TestController : Controller
    {
        // GET: /<controller>/
        [Authorize]
        [HttpGet(nameof(Index))]
        public string Index()
        {
            return "hello";
        }

        [HttpGet]
        [HttpGet(nameof(secondMethod))]
        public async Task<string> secondMethod()
        {
            await WriteOutIdentityInformation();
            return "secontMethod";
        }

        public async Task WriteOutIdentityInformation()
        {
            var identityToken = await HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine(identityToken);

            foreach(var c  in User.Claims)
            {
                Debug.WriteLine($"type: { c.Type} - {c.Value }");
            }
        }
    }
}
