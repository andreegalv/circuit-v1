using WEBComputadora.Model.Computadoras;
using WEBComputadora.Model.Memorias;

namespace WEBComputadora.Model.ComputadorasMemorias
{
    public partial class ComputadoraMemoria
    {
        public Computadora Computadora { get; set; }
        public Memoria Memoria { get; set; }
    }
}