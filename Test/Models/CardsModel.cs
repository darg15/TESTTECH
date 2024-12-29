namespace Test.Models
{
    public class CardsModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string? Card_Number { get; set; }
        public decimal Balance_Used { get; set; }
        public decimal Balance_Available { get; set; }
    }
}
