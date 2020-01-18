using Microsoft.Owin;
using Owin;
using OWINWindowsAuthentication.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

[assembly:OwinStartup(typeof(OWINWindowsAuthentication.Startup))]
namespace OWINWindowsAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseWindowsAuthentication();
            appBuilder.UseClaimsTransformation(Transformation);
        }

        private async Task<ClaimsPrincipal> Transformation(ClaimsPrincipal incomingPrincipal)
        {
            if (!incomingPrincipal.Identity.IsAuthenticated)
            {
                return incomingPrincipal;
            }

            var name = incomingPrincipal.Identity.Name;

            //perform extra operation from database

            var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name,name),
                            new Claim(ClaimTypes.Role,"Admin"),
                            new Claim(ClaimTypes.Email,"arka@arka.com")
                        };

            var identity = new ClaimsIdentity("windows");
            identity.AddClaims(claims);

            return new ClaimsPrincipal(identity);
        }
    }
}