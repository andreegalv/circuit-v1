using System.Collections.Generic;
using WEBComputadora.Model.Computadoras;
using WEBComputadora.Model.ComputadorasDiscosDuros;
using WEBComputadora.Model.ComputadorasMemorias;
using WEBComputadora.Model.DiscosDuros;
using WEBComputadora.Model.Marcas;
using WEBComputadora.Model.Memorias;
using WEBComputadora.Model.Procesadores;

namespace WEBComputadora.DAL.Interfaces
{
    public interface IDbContext
    {
        List<Computadora> Computadoras { get; set; }
        List<ComputadoraDiscoDuro> ComputadorasDiscosDuros { get; set; }
        List<ComputadoraMemoria> ComputadorasMemorias { get; set; }
        List<DiscoDuro> DiscosDuros { get; set; }
        List<Procesador> Procesadores { get; set; }
        List<Memoria> Memorias { get; set; }
        List<Marca> Marcas { get; set; }

        int GetSeedNumber();
    }
}
