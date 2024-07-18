using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBComputadora.Model.ComputadorasMemorias;

namespace WEBComputadora.Services.Interfaces
{
    public interface IRESTComputadoraMemoriaServicio
    {
        IList<ComputadoraMemoria> GetComputers(string descripcion = "", int capacidadIgual = 0, int capacidadMayorGb = 0);
        ComputadoraMemoria GetComputerById(int computadoraId = 0, int computadoraMemoriaId = 0);
    }
}
