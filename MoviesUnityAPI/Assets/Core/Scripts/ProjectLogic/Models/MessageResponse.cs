using System;
using SharedLibrary.Interfaces;

namespace Models
{
    [Serializable]
    internal class MessageResponse : IMessageResponse
    {
        public string Message { get; set; }
    }
}