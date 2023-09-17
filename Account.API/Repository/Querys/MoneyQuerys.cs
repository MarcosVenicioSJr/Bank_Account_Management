namespace MoneyMover.API.Repository.MoneyQuerys
{
    public class MoneyQuerys
    {
        public const string GetBalanceByAccountNumberQuery = @"SELECT * FROM Account 
                                                                    WHERE AccountNumber = @AccountNumber";

        public const string UpdateBalanceQuery = @"UPDATE Account 
                                                     SET Balance = @Balance 
                                                     WHERE AccountNumber = @AccountNumber";

        public const string AddTransactioExtract = @"INSERT INTO Extract 
                                                                 (AccountTo, AccountFrom, Value, TransactionDate)
                                                            VALUES
                                                                (@AccountTo, @AccountFrom, @Value, @TransactionDate)";

        public const string GetExtractsByAccountNumber = @"SELECT * FROM Extract
                                                                    WHERE AccountFrom = @AccountNumber";
    }
}
