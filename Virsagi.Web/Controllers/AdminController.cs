using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Virsagi.Web.Models;
using Virsagi.Web.ViewModels;

namespace Virsagi.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private VirsagiContext db;

        public ActionResult Dashboard()
        {
            db = new VirsagiContext();
            var data = db.HitCounters.FirstOrDefault();
            ViewBag.totalCount = data.TotalCount;
            ViewBag.monthlyCount = data.MonthlyCount;

            return View();
        }

        public ActionResult GetAllAgents(DateTime? filterDate)
        {
            db = new VirsagiContext();
            List<AgentViewModel> data;

            if (filterDate == null)
            {
                data = (from s in db.Agents
                        select new AgentViewModel
                        {
                            AgentID = s.AgentID,
                            RLName = s.RLName,
                            RLNo = s.RLNo,
                            RLAddress = s.RLAddress,
                            ContactNumber = s.ContactNumber,
                            Email = s.Email,
                            CreatedDate = s.CreatedDate ?? DateTime.Now
                        }).ToList();
            }
            else
            {
                data = (from s in db.Agents
                        where DbFunctions.TruncateTime(s.CreatedDate) == filterDate
                        select new AgentViewModel
                        {
                            AgentID = s.AgentID,
                            RLName = s.RLName,
                            RLNo = s.RLNo,
                            RLAddress = s.RLAddress,
                            ContactNumber = s.ContactNumber,
                            Email = s.Email,
                            CreatedDate = s.CreatedDate ?? DateTime.Now
                        }).ToList();
            }

            

            return View(data);
        }

        public ActionResult GetAllRequests(DateTime? filterDate)
        {
            db = new VirsagiContext();
            List<WorkerRequestViewModel> data;

            if (filterDate == null)
            {
                data = (from s in db.WorkerRequests
                        select new WorkerRequestViewModel
                        {
                            RequestTypeString = s.RequestType == 1 ? "Company" : "Agent",
                            ContactPerson = s.ContactPerson,
                            ContactNumber = s.ContactNumber,
                            CompanyUENNumber = s.CompanyUENNumber,
                            CompanyName = s.CompanyName,
                            Email = s.Email,
                            Details = s.Details,
                            SpecialRequest = s.SpecialRequest,
                            CreatedDate = s.CreatedDate
                        }).ToList();
            }
            else
            {
                data = (from s in db.WorkerRequests
                        where DbFunctions.TruncateTime(s.CreatedDate) == filterDate
                        select new WorkerRequestViewModel
                        {
                            RequestTypeString = s.RequestType == 1 ? "Company" : "Agent",
                            ContactPerson = s.ContactPerson,
                            ContactNumber = s.ContactNumber,
                            CompanyUENNumber = s.CompanyUENNumber,
                            CompanyName = s.CompanyName,
                            Email = s.Email,
                            Details = s.Details,
                            SpecialRequest = s.SpecialRequest,
                            CreatedDate = s.CreatedDate
                        }).ToList();
            }

            return View(data);
        }

        public ActionResult EditNews()
        {
            db = new VirsagiContext();

            var data = db.News.FirstOrDefault();

            return View(data);
        }

        [HttpPost]
        public ActionResult EditNews(News news)
        {
            db = new VirsagiContext();

            news.LastUpdatedBy = DateTime.Now;
            db.News.Add(news);
            db.Entry(news).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return View(news);
        }
    }
}