using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBComputadora.Model.ViewModels.Computadoras;
using WEBComputadora.Model.ViewModels.Memorias;

namespace WEBComputadora.Model.ViewModels.ComputadorasMemorias
{
    public class ComputadoraMemoriaGrillaLineaVistaModelo
    {
        public int ComputadoraId { get; set; }
        public int ComputadoraMemoriaId { get; set; }
        public int MemoriaComputadoraId { get; set; }
        public ComputadoraVistaModelo Computadora { get; set; }
        public MemoriaVistaModelo Memoria { get; set; }
    }
}