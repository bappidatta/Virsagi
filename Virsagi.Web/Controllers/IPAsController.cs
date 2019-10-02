using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Virsagi.Web.Models;
using Virsagi.Web.ViewModels;

namespace Virsagi.Web.Controllers
{
    public class IPAsController : Controller
    {
        private VirsagiContext db;

        public ActionResult Index(string workPermitNo)
        {
            var fromDate = DateTime.Now.AddDays(-14);
            var toDate = DateTime.Now;

            db = new VirsagiContext();

            var query = (from s in db.IPAs
                         select new IPAViewModel
                         {
                             IPAID = s.IPAID,
                             PassportNo = s.PassportNo,
                             WorkerName = s.WorkerName,
                             Employer = s.Employer,
                             WorkPermitNo = s.WorkPermitNo,
                             ReferenceNo = s.ReferenceNo,
                             IssuanceDate = s.IssuanceDate
                         }).AsQueryable();

            query = query.Where(x => x.IssuanceDate >= fromDate && x.IssuanceDate <= toDate);

            if(!String.IsNullOrEmpty(workPermitNo))
            {
                query = query.Where(x => x.WorkPermitNo == workPermitNo);
            }

            var data = query.AsEnumerable();

            return View(data);
        }
    }
}