﻿namespace StoreApp.Models
{
    public class LoginModel
    {
        private string? _returnUrl;
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public string ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                    return "/";
                else
                    return _returnUrl;
            }
            set
            {
                _returnUrl = value;
            }
        }
    }
}

