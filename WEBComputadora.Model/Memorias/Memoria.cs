namespace WEBComputadora.Model.Memorias
{
    public partial class Memoria
    {
        public int MemoriaId { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public string Tipo { get; set; }
        public int MarcaMemoriaId { get; set; }
        public int Frecuencia { get; set; }
    }
}