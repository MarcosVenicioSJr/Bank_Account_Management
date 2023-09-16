namespace Authentication.API.Repository.Querys
{
    public class AccountQuerys
    {
        public const string InsertAccount = @"INSERT INTO Account (AccountNumber, Balance)
                                            VALUES (@AccountNumber, @Balance)";
    }
}
