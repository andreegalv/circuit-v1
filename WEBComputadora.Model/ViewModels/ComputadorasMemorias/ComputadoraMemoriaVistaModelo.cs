using System.Collections.Generic;
using WEBComputadora.Model.Utils.Html;
using WEBComputadora.Model.ViewModels.ComputadorasMemorias;

namespace WEBComputadora.Model.ViewModels.ComputadorasMemorias
{
    public class ComputadoraMemoriaVistaModelo
    {
        public string Title { get; set; }
        public string FormTitle { get; set; }
        public PageSize PageSize { get; set; }

        #region FilterArea => 

        public string DescripcionFilter { get; set; }
        public int CapacidadIgualFilter { get; set; }
        public int CapacidadMayorAFilter { get; set; }

        #endregion

        public ComputadoraMemoriaGrillaVistaModelo Grilla { get; set; }
    }
}