using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OWINWindowsAuthentication.Middleware
{
    public class ClaimsTransformationMiddleware
    {
        readonly ClaimsTransformationOptions _options;
        readonly Func<IDictionary<string, object>,Task> _next;

        public ClaimsTransformationMiddleware(Func<IDictionary<string,object>,Task> next,ClaimsTransformationOptions options)
        {
            _options = options;
            _next = next;
        }

        public async Task Invoke(IDictionary<string,object> env)
        {
            var context = new OwinContext(env);

            if (context.Authentication!=null && context.Authentication.User!=null)
            {
                var transformedPrincipal = await _options.ClaimTransformation(context.Authentication.User);
                context.Authentication.User = transformedPrincipal;
            }

            await _next(env);
        }
    }
}