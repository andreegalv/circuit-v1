using System.Collections.Generic;
using WEBComputadora.Model.ViewModels.Computadoras;

namespace WEBComputadora.Model.ViewModels.Procesadores
{
    public class ProcesadorVistaModelo
    {
        public int ProcesadorId { get; set; }
        public string Descripcion { get; set; }
        public bool IsActivo { get; set; }
        public long Capacidad { get; set; }
        public ICollection<ComputadoraVistaModelo> Computadoras { get; set; }
    }
}