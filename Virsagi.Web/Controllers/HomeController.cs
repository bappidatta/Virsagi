using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Virsagi.Web.Models;
using Virsagi.Web.ViewModels;

namespace Virsagi.Web.Controllers
{
    public class HomeController : Controller
    {
        private VirsagiContext db;

        public ActionResult Index()
        {
            db = new VirsagiContext();

            var news = (from s in db.News
                        select new NewsViewModel
                        {
                            NewsID = s.NewsID,
                            NewsHeadline1 = s.NewsHeadline1,
                            NewsDetails1 = s.NewsDetails1,
                            NewsHeadline2 = s.NewsHeadline2,
                            NewsDetails2 = s.NewsDetails2,
                            NewsHeadline3 = s.NewsHeadline3,
                            NewsDetails3 = s.NewsDetails3
                        }).FirstOrDefault();

            return View(news);
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