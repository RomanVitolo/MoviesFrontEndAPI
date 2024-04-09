using System;
using SharedLibrary.Interfaces.Entities;

namespace Models
{
    [Serializable]
    public class LoginModel : IUserInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}