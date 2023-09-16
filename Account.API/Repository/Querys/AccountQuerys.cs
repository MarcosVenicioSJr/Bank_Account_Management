namespace Account.API.Repository.Querys;

public class AccountQuerys
{
    public const string insert = "INSERT INTO Account.AccountClient " +
                                 "(Account, Balance) VALUES('@Account', '@Balance')";
}