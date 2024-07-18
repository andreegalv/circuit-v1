using System.Collections.Generic;
using WEBComputadora.Model.ComputadorasDiscosDuros;
using WEBComputadora.Model.ComputadorasMemorias;
using WEBComputadora.Model.Procesadores;

namespace WEBComputadora.Model.Computadoras
{
    public partial class Computadora
    {
        public ICollection<ComputadoraMemoria> Memorias { get; set; }
        public ICollection<ComputadoraDiscoDuro> DiscosDuros { get; set; }
        public Procesador Procesador { get; set; }
    }
}