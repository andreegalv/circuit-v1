using System.Collections.Generic;
using WEBComputadora.Model.Computadoras;
using WEBComputadora.Model.Marcas;

namespace WEBComputadora.Model.Memorias
{
	public partial class Memoria
    {
		public virtual ICollection<Computadora> Computadoras { get; set; }
        public virtual Marca Marca { get; set; }
    }
}