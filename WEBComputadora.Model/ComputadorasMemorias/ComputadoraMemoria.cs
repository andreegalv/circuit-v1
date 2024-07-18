namespace WEBComputadora.Model.ComputadorasMemorias
{
    public partial class ComputadoraMemoria
    {
        public int ComputadoraId { get; set; }
        public int ComputadoraMemoriaId { get; set; }
        public int Socket { get; set; }
        public int MemoriaComputadoraId { get; set; }

    }
}