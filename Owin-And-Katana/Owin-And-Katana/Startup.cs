using Microsoft.Owin;
using Nancy;
using Nancy.Owin;
using Owin;
using Owin_And_Katana.Middleware;
using System.Diagnostics;
using System.Web.Http;

[assembly: OwinStartup(typeof(Owin_And_Katana.Startup))]

namespace Owin_And_Katana
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseDebugMiddleware(new DebugMiddlewareOptions
            {
                OnIncomingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["DebugStopwatch"] = watch;
                },
                OnOutgoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
                    watch.Stop();
                    Debug.WriteLine("Request took " + watch.ElapsedMilliseconds + " ms");
                }
            });

            //app.Use<DebugMiddleware>(new DebugMiddlewareOptions
            //{
            //    OnIncomingRequest = (ctx) =>
            //    {
            //        var watch = new Stopwatch();
            //        watch.Start();
            //        ctx.Environment["DebugStopwatch"] = watch;
            //    },
            //    OnOutgoingRequest = (ctx) =>
            //    {
            //        var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
            //        watch.Stop();
            //        Debug.WriteLine("Request took " + watch.ElapsedMilliseconds + " ms");
            //    }
            //});

            var setup = new HttpConfiguration();
            setup.MapHttpAttributeRoutes();
            app.UseWebApi(setup);
            //if any request isn't nancy it's will skip this middleware
            //app.Map("/nancy", mappedApp => { mappedApp.UseNancy(); });
            //if request like http://localhost:18237/nancy/adas it's will
            //not found the path and will pass to hello world method
            app.UseNancy(config =>
            {
                config.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound);
            });
            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("<html><head></head><body>Hello World</body></html>");
            });
        }
    }
}