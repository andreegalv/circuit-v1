using System;
using WEBComputadora.Model.ComputadorasMemorias;

namespace WEBComputadora.Model.ViewModels.ComputadorasMemorias
{
	public class ComputadoraMemoriaDisplayViewModel
	{
		public int ComputadoraId { get; set; }
		public int ComputadoraMemoriaId { get; set; }
        public string MemoriaDescripcion { get; set; }
        public string ComputadoraDescripcion { get; set; }
        public int Capacidad { get; set; }
        public int CapacidadGigaByte { get; set; }

        public void ToAssociateModel(ComputadoraMemoria model)
        {
            if (model == null)
                throw new ArgumentNullException();

            ComputadoraId = model.ComputadoraId;
            ComputadoraMemoriaId = model.ComputadoraMemoriaId;
            ComputadoraDescripcion = model.Computadora.Descripcion;
            MemoriaDescripcion = model.Memoria.Descripcion;
        }

    }
}