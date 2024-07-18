using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBComputadora.View.Controllers
{
    [RoutePrefix("error")]
    public class ErrorHandlerController : Controller
    {
        [Route("notfound")]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}