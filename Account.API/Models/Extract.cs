namespace MoneyMover.API.Models
{
    public class Extract
    {
        public int Id { get; set; }
        public string AccountTo { get; set; }
        public string AccountFrom { get; set; }
        public decimal Value { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
