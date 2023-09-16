namespace Authentication.API.Querys;

public class UserQuery
{
    public const string FindByEmail = @"select * from authentication.user where Email = '@Email'";
}