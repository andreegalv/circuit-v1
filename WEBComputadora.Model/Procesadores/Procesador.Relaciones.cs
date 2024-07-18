using System.Collections.Generic;
using WEBComputadora.Model.Computadoras;
using WEBComputadora.Model.Marcas;

namespace WEBComputadora.Model.Procesadores
{
	public partial class Procesador
	{
        public Marca Marca { get; set; }
		public ICollection<Computadora> Computadoras { get; set; }
	}
}