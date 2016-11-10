using Nancy;
using Nancy.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Owin_And_Katana.Modules
{
    public class NancyDemoModules : NancyModule
    {
        public NancyDemoModules()
        {
            Get["/nancy"] = x =>
            {
                var env = Context.GetOwinEnvironment();
                return "Your request from nancy: " + env["owin.RequestPathBase"] + env["owin.RequestPath"];
            };
        }
    }
}