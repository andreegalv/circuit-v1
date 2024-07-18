using System.Collections.Generic;
using WEBComputadora.Model.ViewModels.ComputadorasMemorias;
using WEBComputadora.Model.ViewModels.Procesadores;

namespace WEBComputadora.Model.ViewModels.Computadoras
{
    public class ComputadoraVistaModelo
    {
        public int ComputadoraId { get; set; }
        public string Descripcion { get; set; }
        public int ComputadoraProcesadorId { get; set; }
        public ProcesadorVistaModelo Procesador { get; set; }
        public ICollection<ComputadoraMemoriaVistaModelo> Memorias { get; set; }
    }
}