namespace WEBComputadora.Model.DiscosDuros
{
    public partial class DiscoDuro
    {
        public int DiscoDuroId { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public string Tipo { get; set; }
        public int MarcaDiscoDuroId { get; set; }
    }
}