using System.Collections.Generic;
using WEBComputadora.Model.ViewModels.ComputadorasMemorias;
using WEBComputadora.Model.ViewModels.Computadoras;
using WEBComputadora.Model.ViewModels.Memorias;
using WEBComputadora.Model.Utils.Html;
using System;

namespace WEBComputadora.Model.ViewModels.ComputadorasMemorias
{
    public class ComputadoraMemoriaGrillaVistaModelo
    {
        public ComputadoraMemoriaGrillaVistaModelo()
        {
            Datas = new List<ComputadoraMemoriaGrillaLineaVistaModelo>();
        }

        public int TotalRecords { get; set; }
        public IList<ComputadoraMemoriaGrillaLineaVistaModelo> Datas { get; set; }
        public IPaginator Paginator { get; private set; }

        public void AddPaginator(IPaginator paginator)
        {
            if (paginator == null)
                throw new ArgumentNullException();

            Paginator = paginator;
        }
        
    }
}