using System.Collections.Generic;
using WEBComputadora.Model.Computadoras;
using WEBComputadora.Model.Marcas;

namespace WEBComputadora.Model.DiscosDuros
{
    public partial class DiscoDuro
    {
        public virtual Marca Marca { get; set; }
        public virtual ICollection<Computadora> Computadoras { get; set; }
    }
}