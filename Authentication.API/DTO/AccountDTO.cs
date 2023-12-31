﻿using Authentication.API.Models;

namespace Authentication.API.DTO
{
    public class AccountDTO
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
