using WEBComputadora.Model.Computadoras;
using WEBComputadora.Model.DiscosDuros;

namespace WEBComputadora.Model.ComputadorasDiscosDuros
{
    public partial class ComputadoraDiscoDuro
    {
        public Computadora Computadora { get; set; }
        public DiscoDuro DiscoDuro { get; set; }
    }
}