using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARI.IDP.Testpages
{
    [Route("api/Home")]
    public class HomeController : Controller
    {
        [Route("GetHello")]
        [Authorize]

        public string GetHello() => "hello";


    }
}
