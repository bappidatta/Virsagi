using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Virsagi.Web.Models;
using Virsagi.Web.ViewModels;

namespace Virsagi.Web.Controllers
{
    public class RegisterWorkersController : Controller
    {
        private VirsagiContext db;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AgentViewModel vm)
        {
            if (ModelState.IsValid)
            {
                db = new VirsagiContext();

                var agent = new Agent
                {
                    RLName = vm.RLName,
                    RLNo = vm.RLNo,
                    RLAddress = vm.RLAddress,
                    ContactNumber = vm.ContactNumber,
                    Email = vm.Email
                };

                db.Agents.Add(agent);
                db.SaveChanges();

                TempData["isSuccess"] = 1;

                return RedirectToAction("Index");
            }

            TempData["isSuccess"] = 0;
            return View("Index", vm);
        }
    }
}