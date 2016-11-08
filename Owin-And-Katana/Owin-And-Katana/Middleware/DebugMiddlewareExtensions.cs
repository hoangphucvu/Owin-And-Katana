using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin_And_Katana.Middleware
{
    public static class DebugMiddlewareExtensions
    {
        //use this so in Startup we can treat this as build in method
        public static void UseDebugMiddleware(this IAppBuilder app, DebugMiddlewareOptions options = null)
        {
            if (options == null)
                options = new DebugMiddlewareOptions();

            app.Use<DebugMiddleware>(options);
        }
    }
}