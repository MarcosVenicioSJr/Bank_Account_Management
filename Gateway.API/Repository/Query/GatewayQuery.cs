namespace Gateway.API.Repository.Query
{
    public class GatewayQuery
    {
        public const string GetByEmail = "Select * from User WHERE Email = @Email";
    }
}
