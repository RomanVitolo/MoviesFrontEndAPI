using System;
using SharedLibrary.Interfaces.Entities;

namespace Models
{
    [Serializable]
    internal class UserInfoModel : IUserInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserInfoModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}