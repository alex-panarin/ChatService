using System;

namespace ChatService.Shared.UI
{
    public interface IDisplayMessageService
    {
        void InvokeMessage(MessageInfo message);
    }
}