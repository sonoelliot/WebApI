using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Title = "Home Page";

            //redirects to Swagger page used for the documentation
            return Redirect("http://localhost:29009/Swagger/ui/index");
           // return View();
        }
    }
}
