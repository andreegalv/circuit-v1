using System;
using System.Collections.Generic;
using System.Linq;
using WEBComputadora.DAL.Generators;
using WEBComputadora.DAL.Interfaces;
using WEBComputadora.Model.Computadoras;
using WEBComputadora.Model.ComputadorasDiscosDuros;
using WEBComputadora.Model.ComputadorasMemorias;
using WEBComputadora.Model.DiscosDuros;
using WEBComputadora.Model.Marcas;
using WEBComputadora.Model.Memorias;
using WEBComputadora.Model.Procesadores;

namespace WEBComputadora.DAL.Contexts
{
    public class WebDbContext : IDbContext, IDisposable
    {
        public WebDbContext()
        {
            DatabaseGenerator.Initialize(this);
        }

        public List<Computadora> Computadoras { get; set; }
        public List<ComputadoraDiscoDuro> ComputadorasDiscosDuros { get; set; }
        public List<ComputadoraMemoria> ComputadorasMemorias { get; set; }
        public List<DiscoDuro> DiscosDuros { get; set; }
        public List<Procesador> Procesadores { get; set; }
        public List<Memoria> Memorias { get; set; }   
        public List<Marca> Marcas { get; set; }

        public int GetWaitTimeRequest()
        {
            return WaitTimeRequest;
        }
        public int GetTotalRecordsToCreate()
        {
            return TotalRecordsSeed;
        }
        public int GetSeedNumber()
        {
            return DatabaseGenerator.GetSeed();
        }
        public void Dispose()
        {
            // Disposing class
        }

        public static int WaitTimeRequest { get; set; }
        public static int TotalRecordsSeed => DatabaseGenerator.GetRecordsToCreate();

        public static bool RefreshSeed()
        {
            return DatabaseGenerator.GenerateNewSeed();
        }
        public static void SetRecordsToCreate(int total)
        {
            DatabaseGenerator.SetRecordsToCreate(total);
        }
    }
}