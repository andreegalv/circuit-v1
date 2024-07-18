using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBComputadora.Model.Marcas
{
    public partial class Marca
    {
        public int MarcaId { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
    }
}