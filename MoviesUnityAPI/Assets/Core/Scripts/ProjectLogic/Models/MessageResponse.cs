using SharedLibrary.Interfaces;

namespace Models
{
    public class MessageResponse : IMessageResponse
    {
        public string Message { get; set; }
    }
}