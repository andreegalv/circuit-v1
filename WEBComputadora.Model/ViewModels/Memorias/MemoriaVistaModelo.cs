using System.Collections.Generic;
using WEBComputadora.Model.ViewModels.Computadoras;

namespace WEBComputadora.Model.ViewModels.Memorias
{
    public class MemoriaVistaModelo
    {
        public int MemoriaId { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public int CapacidadGigaBytes { get; set; }
        public int Frecuencia { get; set; }
        public string Tipo { get; set; }

    }
}