using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBComputadora.Model.ComputadorasMemorias;
using WEBComputadora.Services;
using WEBComputadora.Services.Interfaces;

namespace WEBComputadora.Controllers
{
    [RoutePrefix("api/obtener")]
    public class RESTComputadoraMemoriaController : ApiController
    {
        private readonly IRESTComputadoraMemoriaServicio servicio = new RESTComputadoraMemoriaServicio();

        [Route("computadoras"), HttpGet]
        public IList<ComputadoraMemoria> GetComputers(string descripcion = "", int capacidadIgual = 0, int capacidadMayorGb = 0)
        {
            return servicio.GetComputers(descripcion, capacidadIgual, capacidadMayorGb);
        }

        [Route("computadora"), HttpGet]
        public ComputadoraMemoria GetComputerById(int computadoraId = 0, int computadoraMemoriaId = 0)
        {
            return servicio.GetComputerById(computadoraId, computadoraMemoriaId);
        }
    }
}