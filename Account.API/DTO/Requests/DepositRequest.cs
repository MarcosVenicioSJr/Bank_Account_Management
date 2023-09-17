namespace MoneyMover.API.DTO.Requests
{
    public class DepositRequest
    {
        public string AccountNumber { get; set; }
        public decimal BalanceDeposit { get; set; }
    }
}
