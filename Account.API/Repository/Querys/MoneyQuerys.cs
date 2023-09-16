namespace MoneyMover.API.Repository.MoneyQuerys
{
    public class MoneyQuerys
    {
        public const string GetBalanceByAccountNumberQuery = @"SELECT * FROM Account 
                                                                    WHERE AccountNumber = @AccountNumber";

        public const string UpdateBalanceQuery = @"UPDATE Account 
                                                     SET Balance = @Balance 
                                                     WHERE AccountNumber = @AccountNumber";
    }
}
