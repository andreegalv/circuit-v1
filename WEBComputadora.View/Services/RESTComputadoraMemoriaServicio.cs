using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WEBComputadora.DAL.Contexts;
using WEBComputadora.DAL.Repositories;
using WEBComputadora.Model.ComputadorasMemorias;
using WEBComputadora.Services.Interfaces;
using WEBComputadora.View.Utils;

namespace WEBComputadora.Services
{
    public class RESTComputadoraMemoriaServicio : IRESTComputadoraMemoriaServicio
    {
        public IList<ComputadoraMemoria> GetComputers(string descripcion = "", int capacidadIgual = 0, int capacidadMayorGb = 0)
        {
            using (var repository = new ComputadoraMemoriaRepository(new WebDbContext()))
            {
                IEnumerable<ComputadoraMemoria> computers = repository.GetAll();

                if (!string.IsNullOrEmpty(descripcion))
                    computers = computers.Where(c => c.Memoria.Descripcion.ToUpper().Contains(descripcion.ToUpper()));

                if (capacidadIgual > 0)
                    computers = computers.Where(c => c.Memoria.Capacidad == capacidadIgual);

                if (capacidadMayorGb > 0)
                    computers = computers.Where(c => ConvertTypeMemory.ConvertMegaToGiga(c.Memoria.Capacidad) > capacidadMayorGb);

                int waitTime = WebDbContext.WaitTimeRequest;

                if (waitTime > 0)
                    Thread.Sleep(WebDbContext.WaitTimeRequest);

                return computers.ToList();                
            }
        }
        public ComputadoraMemoria GetComputerById(int computadoraId = 0, int computadoraMemoriaId = 0)
        {
            using (var repository = new ComputadoraMemoriaRepository(new WebDbContext()))
            {
                int waitTime = WebDbContext.WaitTimeRequest;

                if (waitTime > 0)
                    Thread.Sleep(WebDbContext.WaitTimeRequest);

                return repository.GetById(computadoraId, computadoraMemoriaId);
            }
        }
    }
}