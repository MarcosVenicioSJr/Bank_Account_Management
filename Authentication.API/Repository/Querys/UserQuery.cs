namespace Authentication.API.Querys;

public class UserQuery
{
    public const string FindByEmail = @"SELECT * FROM authentication.user WHERE Email = @Email";

    public const string InsertUser = @"INSERT INTO User (Name, Email, Password) 
                                VALUES (@Name, @Email, @Password)";

    public const string InsertAccount = @"INSERT INTO Account(AccountNumber, Balance, UserId) 
                                            VALUES (@AccountNumber, @Balance, @UserId)";

}