﻿namespace Cf.Libs.Service.Dtos.Account
{
    public class SigninDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}