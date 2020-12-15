using ChatService.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatService.Shared.UI
{
    public class MessageInfo
    {
        public MessageType Type { get; set; }
        public string Info { get; set; }

        public override string ToString()
        {
            return Info;
        }
    }
}
