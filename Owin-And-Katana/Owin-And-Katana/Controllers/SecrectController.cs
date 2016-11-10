using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Owin_And_Katana.Controllers
{
    [Authorize]
    public class SecrectController : Controller
    {
        // GET: Secrect
        public ActionResult Index()
        {
            return View();
        }
    }
}