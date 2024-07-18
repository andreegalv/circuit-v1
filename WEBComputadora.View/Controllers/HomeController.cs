using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBComputadora.DAL.Contexts;
using WEBComputadora.View.Services;
using WEBComputadora.View.Services.Interfaces;
using WEBComputadora.View.Utils;

namespace WEBComputadora.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        private readonly IHomeService service = new HomeService();

        [Route(""), HttpGet]
        public ActionResult Index()
        {
            return View(service.GetIndexModel());
        }

        [Route("update/seed"), HttpGet]
        public ActionResult UpdateSeed()
        {
            service.UpdateSeedFromContext();
            return RedirectToAction("Index");
        }
        [Route("update/wait-time-request"), HttpPost]
        public ActionResult UpdateWaitTimeRequest(int? waitTimeRequest, int? totalRecordsCreate)
        {
            bool isOk = false;

            if (service.SetConfiguration(waitTimeRequest, totalRecordsCreate))
                isOk = true;

            return Json(new { Ok = isOk, WebDbContext.WaitTimeRequest, WebDbContext.TotalRecordsSeed });
        }
    }
}