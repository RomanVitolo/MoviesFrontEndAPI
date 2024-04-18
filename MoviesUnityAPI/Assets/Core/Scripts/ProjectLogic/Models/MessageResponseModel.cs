using System;
using SharedLibrary.Interfaces;

namespace Models
{
    [Serializable]
    internal class MessageResponseModel : IMessageResponse
    {
        public string Message { get; set; }
    }
}