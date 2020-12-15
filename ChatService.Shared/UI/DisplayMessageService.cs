using ChatService.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatService.Shared.UI
{
    public class DisplayMessageService : IDisplayMessageService
    {
        public DisplayMessageService(Action<MessageInfo> displayMessage)
        {
            DisplayMessage = displayMessage;
        }
        public Action<MessageInfo> DisplayMessage { get; private set; }

        public void InvokeMessage(MessageInfo message)
        {
            
            DisplayMessage?.BeginInvoke(message, (res) =>
            { 
                DisplayMessage?.EndInvoke(res);

            }, null);
        }
    }
}
