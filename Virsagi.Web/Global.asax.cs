using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Virsagi.Web.Models;

namespace Virsagi.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];

            if(cookie != null && cookie.Value != null)
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cookie.Value);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }

            AddHitCount();
        }

        private void AddHitCount()
        {
            using (VirsagiContext db = new VirsagiContext())
            {
                var hitCounter = db.HitCounters.FirstOrDefault();
                hitCounter.TotalCount++;
                db.HitCounters.Add(hitCounter);
                db.Entry(hitCounter).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
