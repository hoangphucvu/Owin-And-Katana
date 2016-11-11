using Microsoft.Owin.Security;
using Owin_And_Katana.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Owin_And_Katana.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (model.Username.Equals("tony") && model.Password.Equals("123"))
            {
                var identity = new ClaimsIdentity("ApplicationCookie");
                identity.AddClaims(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,model.Username),
                    new Claim(ClaimTypes.Name,model.Username)
                });
                HttpContext.GetOwinContext().Authentication.SignIn(identity);
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }

        public ActionResult LoginFacebook()
        {
            HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
            {
                RedirectUri = "/Secrect/Index"
            }, "Facebook");
            return new HttpUnauthorizedResult();
        }
    }
}