using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatService.Shared.Messages
{
    public class PayloadMessage : Message
    {
        public PayloadMessage(MessageType type, string from, string to) :
            base(type, from, to)
        {
        }

        public string Payload { get; set; }
        internal override byte[] ToByteArray()
        {
            return Encoding.UTF8.GetBytes($"{Type}:{From}:{To}@{Payload}|");
        }
    }
}
