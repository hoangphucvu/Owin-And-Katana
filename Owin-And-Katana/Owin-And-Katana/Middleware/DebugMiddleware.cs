using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<
    System.Collections.Generic.IDictionary<string, object>,
    System.Threading.Tasks.Task>;

namespace Owin_And_Katana.Middleware
{
    public class DebugMiddleware
    {
        private AppFunc _next;

        public DebugMiddleware(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> enviroment)
        {
            var ctx = new OwinContext(enviroment);
            var path = (string)enviroment["owin.RequestPath"];
            Debug.WriteLine("Incoming request: " + ctx.Request.Path);
            await _next(enviroment);
            Debug.WriteLine("Outgoing request: " + ctx.Request.Path);
        }
    }
}