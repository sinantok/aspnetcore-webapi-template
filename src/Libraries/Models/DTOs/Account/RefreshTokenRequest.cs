using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTOs.Account
{
    public class RefreshTokenRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
