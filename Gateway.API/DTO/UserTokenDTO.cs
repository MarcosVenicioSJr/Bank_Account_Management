namespace Gateway.API.DTO
{
    public class UserTokenDTO
    {
        public string Email { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string Token { get; set; }
    }
}
