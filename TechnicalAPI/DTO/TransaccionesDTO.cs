namespace TechnicalAPI.DTO
{
    public class TransaccionesDTO
    {
        
        public string? Nombre_cliente { get;set; }
        public string? Numero_tarjeta { get;set; }

        public int Numero_autorizacion { get; set; }
        public DateTime Fecha {  get; set; }
        public string? Descr { get; set; }
        public decimal Cargo { get; set; }
        public decimal Abono { get; set; }
    }
}
