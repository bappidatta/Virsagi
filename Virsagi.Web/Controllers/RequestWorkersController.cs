using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Virsagi.Web.Models;
using Virsagi.Web.ViewModels;

namespace Virsagi.Web.Controllers
{
    public class RequestWorkersController : Controller
    {
        private VirsagiContext db;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WorkerRequestViewModel vm)
        {
            if(ModelState.IsValid)
            {
                db = new VirsagiContext();

                var workerRequest = new WorkerRequest
                {
                    RequestType = vm.RequestType,
                    ContactPerson = vm.ContactPerson,
                    ContactNumber = vm.ContactNumber,
                    CompanyUENNumber = vm.CompanyUENNumber,
                    CompanyName = vm.CompanyName,
                    Email = vm.Email,
                    Details = vm.Details,
                    SpecialRequest = vm.SpecialRequest,
                    CreatedDate = vm.CreatedDate
                };

                db.WorkerRequests.Add(workerRequest);
                db.SaveChanges();

                TempData["isSuccess"] = 1;

                return RedirectToAction("Index");
            }

            TempData["isSuccess"] = 0;
            return View("Index", vm);
        }
    }
}