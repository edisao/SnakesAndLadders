
namespace Domain.Entities
{
    public class Token
    {
        public int PosicionActual { get; set; }
        public int PosicionAnterior { get; set; }
        public int CantidadSaltos { get; set; }
        public bool GeneraMovimientoAdicional { get; set; }
        public bool ExcedeTamanioTablero { get; set; } = false;
        public bool JuegoGanado { get; set; } = false;
        public int ValorMovimientoAdicional { get; set; } = 0;
        public string TipoMovimiento { get; set; } = string.Empty;
        
        public Token()
        {
        }
    }
}
