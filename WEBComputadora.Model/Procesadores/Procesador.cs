namespace WEBComputadora.Model.Procesadores
{
    public partial class Procesador
    {
        public int ProcesadorId { get; set; }
        public string Descripcion { get; set; }
        public string Linea { get; set; }
        public int Capacidad { get; set; }
        public int MarcaProcesadorId { get; set; }
    }
}