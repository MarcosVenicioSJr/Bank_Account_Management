namespace Gateway.API.DTO
{
    public class DepositRequest
    {
        public string AccountNumber { get; set; }
        public decimal BalanceDeposit { get; set; }
    }
}
