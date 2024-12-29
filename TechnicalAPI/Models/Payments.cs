namespace TechnicalAPI.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public int IdCard { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Amount { get; set; }
    }
}
