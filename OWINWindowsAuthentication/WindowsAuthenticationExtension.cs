using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace OWINWindowsAuthentication
{
    public static class WindowsAuthenticationExtension
    {
        public static IAppBuilder UseWindowsAuthentication(this IAppBuilder appBuilder)
        {
            object value;
            if (appBuilder.Properties.TryGetValue("System.Net.HttpListener",out value))
            {
                var appListener = value as HttpListener;
                if (appListener!=null)
                {
                    appListener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
                }
            }

            return appBuilder;
        }
    }
}