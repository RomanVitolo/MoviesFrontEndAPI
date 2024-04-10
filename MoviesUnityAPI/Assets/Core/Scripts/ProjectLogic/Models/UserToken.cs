using System;
using SharedLibrary.Interfaces.Entities;

namespace Models
{
    [Serializable]
    internal class UserToken : IUserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }      
    }
}