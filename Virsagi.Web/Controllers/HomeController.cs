using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Virsagi.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Change(string lnAbbrevation)
        {
            if(lnAbbrevation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lnAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lnAbbrevation);
            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lnAbbrevation;
            Response.Cookies.Add(cookie);

            return View("Index");
        }
    }
}