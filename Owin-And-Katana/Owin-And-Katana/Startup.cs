using Microsoft.Owin;
using Owin;
using Owin_And_Katana.Middleware;

[assembly: OwinStartup(typeof(Owin_And_Katana.Startup))]

namespace Owin_And_Katana
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.Use<DebugMiddleware>();
            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("<html><head></head><body>Hello World</body></html>");
            });
        }
    }
}