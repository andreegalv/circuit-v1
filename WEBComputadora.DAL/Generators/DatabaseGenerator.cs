using System;
using System.Collections.Generic;
using System.Linq;
using WEBComputadora.DAL.Interfaces;
using WEBComputadora.Model.Computadoras;
using WEBComputadora.Model.ComputadorasDiscosDuros;
using WEBComputadora.Model.ComputadorasMemorias;
using WEBComputadora.Model.DiscosDuros;
using WEBComputadora.Model.Marcas;
using WEBComputadora.Model.Memorias;
using WEBComputadora.Model.Procesadores;

namespace WEBComputadora.DAL.Generators
{
    public class DatabaseGenerator
    {
        static DatabaseGenerator()
        {
            totalRecordsToCreate = 30;
            random = new Random();
        }

        private static int totalRecordsToCreate;
        private const int baseMegabytes = 1024;
        private static Random random;
        private static bool isDataPopulated;
        private static int seedNumber;
        private static IDbContext contextSeed;

        public static void Initialize(IDbContext context)
        {
            if (!isDataPopulated)
            {
                contextSeed = context;
                GenerateDatabase();

                isDataPopulated = true;
            }
            else
            {
                SetContext(context);
            }
        }
        public static bool GenerateNewSeed()
        {
            if (seedNumber <= 0)
                throw new InvalidOperationException("You must use the Initialize method before refresh any seed");

            GenerateDatabase();

            return true;
        }
        public static int GetSeed()
        {
            return seedNumber;
        }
        public static int GetRecordsToCreate()
        {
            return totalRecordsToCreate;
        }
        public static void SetRecordsToCreate(int totalRecords)
        {
            if (totalRecords <= 0 || totalRecords > 100)
                throw new ArgumentOutOfRangeException();

            totalRecordsToCreate = totalRecords;
        }

        private static void SetContext(IDbContext context)
        {
            context.Marcas = contextSeed.Marcas;
            context.Memorias = contextSeed.Memorias;
            context.DiscosDuros = contextSeed.DiscosDuros;
            context.Procesadores = contextSeed.Procesadores;
            context.Computadoras = contextSeed.Computadoras;
            context.ComputadorasDiscosDuros = contextSeed.ComputadorasDiscosDuros;
            context.ComputadorasMemorias = contextSeed.ComputadorasMemorias;
        }

        #region Generators =>

        private static void GenerateDatabase()
        {
            if (contextSeed == null)
                throw new InvalidOperationException("there is not any instance of a class that implement IDbContext");

            seedNumber = random.Next(100000, 999999);

            contextSeed.Computadoras = new List<Computadora>();
            contextSeed.ComputadorasDiscosDuros = new List<ComputadoraDiscoDuro>();
            contextSeed.ComputadorasMemorias = new List<ComputadoraMemoria>();
            contextSeed.DiscosDuros = new List<DiscoDuro>();
            contextSeed.Procesadores = new List<Procesador>();
            contextSeed.Memorias = new List<Memoria>();
            contextSeed.Marcas = new List<Marca>();

            GenerateMarcas();
            GenerateDiscosDuros();
            GenerateMemorias();
            GenerateProcesadores();
            GenerateComputadoras();
        }

        private static void GenerateMarcas()
        {
            var brandsDicionary = GetAllBrands();

            foreach (var brandCategory in brandsDicionary)
            {
                string[] brandsArray = brandCategory.Value.Split(';');

                for (int i = 0; i < brandsArray.Length; i++)
                {
                    var marca = new Marca()
                    {
                        MarcaId = i + 1,
                        Descripcion = brandsArray[i],
                        Categoria = brandCategory.Key
                    };

                    contextSeed.Marcas.Add(marca);
                }
            }
        }
        private static void GenerateDiscosDuros()
        {
            int totalArray = 30;
            int[] CapacidadArray = GetCapacitySizeArray(500, 2000, totalArray);

            for (int i = 0; i < totalRecordsToCreate; i++)
            {
                var discoDuro = new DiscoDuro()
                {
                    DiscoDuroId = i + 1,
                    Descripcion = $"DISCO DURO DE SERIE Nº { GetRandomNumberInt(1000000, 9000000).ToString() }",
                    Capacidad = CapacidadArray[random.Next(0 , totalArray)] * baseMegabytes
                };

                contextSeed.DiscosDuros.Add(discoDuro);
            }
        }
        private static void GenerateMemorias()
        {
            int totalArray = 40;

            int[] CapacidadArray = GetCapacitySizeArray(1, 16, totalArray);
            string[] tiposMemoriasArray = new string[] { "DDR2;667", "DDR3;1333", "DDR4;2400" };

            for (int i = 0; i < totalRecordsToCreate; i++)
            {
                string[] tipoArray = tiposMemoriasArray[random.Next(0, tiposMemoriasArray.Length - 1)].Split(';');
                string tipo = tipoArray[0];
                int frecuencia = (int.TryParse(tipoArray[1], out int result)) ? result : 0;
                int capacidadGb = 0;

                switch(tipo)
                {
                    case "DDR2":
                        capacidadGb = CapacidadArray.Where(c => c <= 2).FirstOrDefault();
                        break;
                    case "DDR3":
                        capacidadGb = CapacidadArray.Where(c => c >= 4 && c <= 6).FirstOrDefault();
                        break;
                    case "DDR4":
                        capacidadGb = CapacidadArray.Where(c => c >= 6 && c <= 16).FirstOrDefault();
                        break;
                }

                var marca = GetRandomEntityFromCollection(
                        contextSeed.Marcas.Where(m => m.Categoria.Equals("MEMORIA")).ToList());
                var memoria = new Memoria()
                {
                    MemoriaId = i + 1,
                    Descripcion = $"{marca.Descripcion.ToUpper()} {tipo.ToUpper()} {capacidadGb.ToString()}GB {frecuencia.ToString()}MHz",
                    Capacidad = capacidadGb * baseMegabytes,
                    MarcaMemoriaId = marca.MarcaId,
                    Marca = marca,
                    Tipo = tipo,
                    Frecuencia = frecuencia
                };

                contextSeed.Memorias.Add(memoria);
            }
        }
        private static void GenerateProcesadores()
        {
            string[] lineasProcesadoresArray = new string[] { "[INTEL];CORE I3=1151", "[INTEL];CORE I5=1151", "[INTEL];CORE I7=1151-v2",
                                                                "[AMD];RYZEN 3=AM4", "[AMD];RYZEN 5=AM4", "[AMD];RYZEN 7=AM4"};

            int totalArray = 40;
            int[] CapacidadArray = GetCapacitySizeArray(20, 40, totalArray);
            int capacidadGhz = 0;

            for (int i = 0; i < totalRecordsToCreate; i++)
            {
                string[] lineaArray = lineasProcesadoresArray[random.Next(0, lineasProcesadoresArray.Length - 1)].Split(';');

                string marcaDescripcion = lineaArray[0].Replace("[", "").Replace("]", "");
                string linea = lineaArray[1].Split('=')[0];
                string socket = lineaArray[1].Split('=')[1];

                if (contextSeed.Marcas.Exists(m => m.Descripcion.ToUpper() == marcaDescripcion.ToUpper()))
                {
                    var marca = contextSeed.Marcas.Where(m => m.Descripcion.ToUpper() == marcaDescripcion.ToUpper())
                                        .First();

                    switch (linea)
                    {
                        case "CORE I3":
                        case "RYZEN 3":
                            capacidadGhz = CapacidadArray.Where(c => c <= 30).FirstOrDefault();
                            break;
                        case "CORE I4":
                        case "RYZEN 5":
                        case "CORE I5":
                        case "RYZEN 7":
                            capacidadGhz = CapacidadArray.Where(c => c > 30 && c <= 40).FirstOrDefault();
                            break;
                    }

                    var procesador = new Procesador()
                    {
                        ProcesadorId = i + 1,
                        Descripcion = $"CPU {linea} {capacidadGhz} GHZ ({socket})",
                        Capacidad = capacidadGhz * 1000,
                        Marca = marca,
                        Linea = linea
                    };
                    contextSeed.Procesadores.Add(procesador);
                }
            }
        }
        private static void GenerateComputadoras()
        {
            for (int i = 0; i < totalRecordsToCreate; i++)
            {
                var procesador = GetRandomEntityFromCollection(contextSeed.Procesadores);
                double capacidadProcesadorGhz = Convert.ToDouble(procesador.Capacidad) / 10000;

                var computadora = new Computadora()
                {
                    ComputadoraId = i + 1,
                    Descripcion = $"DESKTOP {procesador.Marca.Descripcion} {procesador.Linea} {capacidadProcesadorGhz.ToString("N1").Replace(",", ".")}G",
                    ProcesadorComputadoraId = (procesador != null) ? procesador.ProcesadorId : 0,
                    Procesador = (procesador != null) ? procesador : null
                };

                procesador.Computadoras = new List<Computadora>();
                procesador.Computadoras.Add(computadora);

                // Genera memorias RAM
                int totalSockets = random.Next(1, 4) + 1;
                int totalMemoriasGenerar = random.Next(1, totalSockets) + 1;
                for (int j = 0; j < totalMemoriasGenerar; j++)
                {
                    Memoria memoria = GetRandomEntityFromCollection(contextSeed.Memorias);

                    var computadoraMemoria = new ComputadoraMemoria
                    {
                        ComputadoraId = computadora.ComputadoraId,
                        ComputadoraMemoriaId = j + 1,
                        MemoriaComputadoraId = (memoria != null) ? memoria.MemoriaId : 0,
                        Socket = j,
                        Memoria = memoria,
                        Computadora = computadora
                    };
                    contextSeed.ComputadorasMemorias.Add(computadoraMemoria);

                    if (memoria.Computadoras == null)
                        memoria.Computadoras = new List<Computadora>();

                    memoria.Computadoras.Add(computadora);

                    if (computadora.Memorias == null)
                        computadora.Memorias = new List<ComputadoraMemoria>();

                    computadora.Memorias.Add(computadoraMemoria);
                }

                // Genero discos duros
                int totalDiscosDurosGenerar = random.Next(1, 4) + 1;
                for (int k = 0; k < totalDiscosDurosGenerar; k++)
                {
                    DiscoDuro discoDuro = GetRandomEntityFromCollection(contextSeed.DiscosDuros);

                    var computadoraDiscoDuro = new ComputadoraDiscoDuro
                    {
                        ComputadoraId = computadora.ComputadoraId,
                        ComputadoraDiscoDuroId = k + 1,
                        DiscoDuroComputadoraId = (discoDuro != null) ? discoDuro.DiscoDuroId : 0,
                        DiscoDuro = (discoDuro != null) ? discoDuro : null,
                        Computadora = computadora
                    };
                    contextSeed.ComputadorasDiscosDuros.Add(computadoraDiscoDuro);

                    if (discoDuro.Computadoras == null)
                        discoDuro.Computadoras = new List<Computadora>();

                    discoDuro.Computadoras.Add(computadora);

                    if (computadora.DiscosDuros == null)
                        computadora.DiscosDuros = new List<ComputadoraDiscoDuro>();

                    computadora.DiscosDuros.Add(computadoraDiscoDuro);
                }

                computadora.Descripcion += $" {computadora.Memorias.Sum(m => m.Memoria.Capacidad / 1024)}GB";

                contextSeed.Computadoras.Add(computadora);
            }
        }

        private static T GetRandomEntityFromCollection<T>(List<T> collection)
        {
            if (collection.Count <= 0)
                return default(T);

            int indice = GetRandomNumberInt(1, collection.Count);
            return collection.ElementAt(indice);
        }
        private static int GetRandomNumberInt(int min, int max)
        {
            if (min < 0)
                throw new ArgumentOutOfRangeException();

            if (min > max)
                throw new ArgumentException();

            return random.Next(min, max);
        }
        private static int[] GetCapacitySizeArray(int minGigaByte, int maxGigaByte, int totalArray)
        {
            if (totalArray <= 0)
                throw new IndexOutOfRangeException();

            if (minGigaByte <= 0 || maxGigaByte <= 0)
                throw new ArgumentOutOfRangeException();

            if (minGigaByte > maxGigaByte)
                throw new ArgumentOutOfRangeException();

            int[] capacityArray = new int[totalArray];

            for (int i = 0; i < totalArray; i++)
            {
                capacityArray[i] = random.Next(minGigaByte, maxGigaByte);
            }

            return capacityArray;
        }
        private static string GetBrandDescriptionFromCategory(string categoria)
        {
            var categoryDiccionary = GetAllBrands();

            if (categoryDiccionary.ContainsKey(categoria.ToUpper()))
            {
                string[] categories = categoryDiccionary[categoria.ToUpper()].Split(';');

                if (categories.Count() > 0)
                {
                    return categories[random.Next(0, categories.Length - 1)];
                }
            }

            return null;
        }
        private static Dictionary<string, string> GetAllBrands()
        {
            var categoryDiccionary = new Dictionary<string, string>();

            categoryDiccionary.Add("MEMORIA", "CORSAIR;KINGSTONE;CRUCIAL;HYPERX;G.SKILL;BALLISTIK");
            categoryDiccionary.Add("DISCOSDUROS", "SPEKTRA;ADATA;LEXAR;GIGABYTE;WD;TOSHIBA;SCANDISK;QNAP;SEAGATE");
            categoryDiccionary.Add("PROCESADORES", "AMD;INTEL");
            categoryDiccionary.Add("DESKTOP", "GEAR");

            return categoryDiccionary;
        }

        #endregion
    }
}