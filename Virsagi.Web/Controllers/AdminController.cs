using System;
using System.Collections.Generic;
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

        public ActionResult GetAllAgents()
        {
            db = new VirsagiContext();

            var data = (from s in db.Agents
                        select new AgentViewModel
                        {
                            AgentID = s.AgentID,
                            RLName = s.RLName,
                            RLNo = s.RLNo,
                            RLAddress = s.RLAddress,
                            ContactNumber = s.ContactNumber,
                            Email = s.Email
                        }).AsEnumerable();

            return View(data);
        }

        public ActionResult GetAllRequests()
        {
            db = new VirsagiContext();

            var data = (from s in db.WorkerRequests
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
                        }).AsEnumerable();

            return View(data);
        }
    }
}