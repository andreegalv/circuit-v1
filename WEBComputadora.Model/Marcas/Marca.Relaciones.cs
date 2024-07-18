using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBComputadora.Model.Memorias;

namespace WEBComputadora.Model.Marcas
{
    public partial class Marca
    {
        public ICollection<Memoria> Memorias { get; set; }
    }
}