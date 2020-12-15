using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatService.Shared.Messages
{
    public enum MessageType
    {
        Connect,
        Disconnect,
        List,
        Call,
        Text,
        Feedback,
        Error
    }

    public enum PayloadType
    {
        Text,
        Speech
    }
    public enum FeedbackType
    {
        Success = 1,
        Failed,
        Denied
    }
}
