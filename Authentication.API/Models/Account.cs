namespace Authentication.API.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public int Balance { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
