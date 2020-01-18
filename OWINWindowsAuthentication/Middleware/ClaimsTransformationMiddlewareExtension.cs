using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace OWINWindowsAuthentication.Middleware
{
    public static class ClaimsTransformationMiddlewareExtension
    {
        public static IAppBuilder UseClaimsTransformation(this IAppBuilder appBuilder,Func<ClaimsPrincipal,Task<ClaimsPrincipal>> options)
        {
            return appBuilder.UseClaimsTransformation(new ClaimsTransformationOptions() {
                    ClaimTransformation=options});
        }

        public static IAppBuilder UseClaimsTransformation(this IAppBuilder appBuilder,ClaimsTransformationOptions options)
        {
            if (options==null)
            {
                throw new ArgumentNullException("options");
            }

            appBuilder.Use(typeof(ClaimsTransformationMiddleware),options);

            return appBuilder;
        }
    }
}