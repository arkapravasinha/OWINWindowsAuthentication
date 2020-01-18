using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace OWINWindowsAuthentication.Controllers
{
    public class TestController : ApiController
    {
        [Authorize]
        public async Task<IHttpActionResult> Get()
        {
            var user = User as ClaimsPrincipal;
            var data= from c in user.Claims
                      select c;
            return Ok(data);
        }
    }
}
