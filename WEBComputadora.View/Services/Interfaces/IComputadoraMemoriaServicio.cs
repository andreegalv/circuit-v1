using System.Threading.Tasks;
using WEBComputadora.Model.ViewModels.ComputadorasMemorias;

namespace WEBComputadora.View.Services.Interfaces
{
    public interface IComputadoraMemoriaServicio
    {
        ComputadoraMemoriaVistaModelo GetIndex();
        Task<ComputadoraMemoriaGrillaVistaModelo> GetComputersAsync(string descripcion, int? capacidadIgual, int? capacidadMayorGb,
                                                        int? pageSize, bool? changePage, int? toPage);
        Task<ComputadoraMemoriaDisplayViewModel> GetComputerByIdAsync(int? computadoraId, int? computadoraMemoriaId);
    }
}
