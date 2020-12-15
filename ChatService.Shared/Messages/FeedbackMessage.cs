using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatService.Shared.Messages
{
    public class FeedbackMessage : Message
    {
        public FeedbackMessage(string from, string to) : 
            base(MessageType.Feedback, from, to)
        {
        }

        public FeedbackType Feedback { get; set; }

        internal override byte[] ToByteArray()
        {
            return Encoding.UTF8.GetBytes($"{Type}:{From}:{To}@{Feedback}|");
        }
    }
}
