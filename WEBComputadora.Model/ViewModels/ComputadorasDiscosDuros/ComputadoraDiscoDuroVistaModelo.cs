using WEBComputadora.Model.ViewModels.Computadoras;
using WEBComputadora.Model.ViewModels.DiscosDuros;

namespace WEBComputadora.Model.ViewModels.ComputadorasDiscosDuros
{
    public class ComputadoraDiscoDuroVistaModelo
    {
        public int ComputadoraId { get; set; }
        public int ComputadoraDiscoDuroId { get; set; }
        public int DiscoDuroComputadoraId { get; set; }
        public DiscoDuroVistaModelo DiscoDuro { get; set; }
        public ComputadoraVistaModelo Computadora { get; set; }
    }
}