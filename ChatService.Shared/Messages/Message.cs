using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatService.Shared.Messages
{
    public class Message
    {
        public Message(MessageType type, string from, string to)
        {
            Type = type;
            From = from;
            To = to;
        }
        public MessageType Type { get; }
        public string From { get; }
        public string To { get; }

        internal virtual byte[] ToByteArray()
        {
            return Encoding.UTF8.GetBytes($"{Type}:{From}:{To}|");
        }
    }
}
