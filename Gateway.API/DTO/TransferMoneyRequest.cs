namespace Gateway.API.DTO
{
    public class TransferMoneyRequest
    {
        public string AccountTo { get; set; }
        public string AccountFrom { get; set; }
        public decimal Value { get; set; }
    }
}
