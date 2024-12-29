using TechnicalAPI.Models;

namespace TechnicalAPI.DTO
{
    public class EstadoDTO
    {
        public string? Nombre_cliente { get; set; }
        public string? Numero_tarjeta { get; set; }
        public decimal Saldo_total { get; set; }
        public decimal Cuota_minima { get; set; }
        public decimal Pago_intereses { get; set; }

        public List<MovDTO>? Movs{ get; set;}
    }
}
