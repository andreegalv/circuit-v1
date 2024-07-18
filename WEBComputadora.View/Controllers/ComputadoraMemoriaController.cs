using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEBComputadora.DAL.Contexts;
using WEBComputadora.View.Services;
using WEBComputadora.View.Services.Interfaces;

namespace WEBComputadora.Controllers
{
    [RoutePrefix("computadoras")]
    public class ComputadoraMemoriaController : Controller
    {
        private readonly IComputadoraMemoriaServicio servicio = new ComputadoraMemoriaServicio();

        private const string partialViewsPath = "~/Views/ComputadoraMemoria";

        [Route("ver"), HttpGet]
        public async Task<ActionResult> Display(int? computadoraId, int? computadoraMemoriaId)
        {
            var modelo = await servicio.GetComputerByIdAsync(computadoraId, computadoraMemoriaId)
                                    .ConfigureAwait(false);

            if (modelo != null)
            {
                return View(modelo);
            }
            return RedirectToAction("NotFound", "ErrorHandler");
        }
        [Route(""), HttpGet]
        public ActionResult Index()
        {
            var model = servicio.GetIndex();
            return View(model);
        }
        [Route("IndexGridAsync"), HttpPost]
        public async Task<ActionResult> IndexGridAsync(string descripcion, int? capacidadIgual, int? capacidadMayorGB, 
                                            int? pageSize, bool? changePage, int? toPage)
        {
            var modelo = await servicio.GetComputersAsync(descripcion, capacidadIgual, capacidadMayorGB, 
                                                            pageSize, changePage, toPage).ConfigureAwait(false);

            return PartialView(partialViewsPath + "/IndexGridAsync.cshtml", modelo);
        }
        
    }
}