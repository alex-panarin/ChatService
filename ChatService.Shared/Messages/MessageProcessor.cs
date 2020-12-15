using ChatService.Shared.Connections;
using ChatService.Shared.Interfaces;
using ChatService.Shared.Models;
using System;
using System.Collections.Generic;

using System.Text;

namespace ChatService.Shared.Messages
{
    public class MessageProcessor
    {
        private readonly Connection _connnection;
        

        public MessageProcessor(Connection connection)
        {
            _connnection = connection;
        }

        public IEnumerable<Message> ProcessRequest(byte[] request, int size)
        {
            if (size == 0) yield return null;

            byte[] bodyes = new byte[size];
            Array.Copy(request, bodyes, size);

            string[] messages = Encoding.UTF8.GetString(bodyes).Split('|');

            foreach (var item in messages)
            {
                if (string.IsNullOrEmpty(item)) continue;

                var body = item.Split('@');
                
                string[] headers = body[0].Split(':');

                var message = CreateMessageByType((MessageType)Enum.Parse(typeof(MessageType), headers[0]), headers[1], headers[2]);
                if (message is PayloadMessage pm)
                {
                    pm.Payload = body.Length == 1 ? string.Empty : body[1];
                }

                if (message is FeedbackMessage fm)
                {
                    fm.Feedback = body.Length == 1 ? FeedbackType.Failed : (FeedbackType)Enum.Parse(typeof(FeedbackType), body[1]);
                }

                yield return message;
            }
            
        }

        public IEnumerable<Message> ProcessResponce(Message request)
        {
            switch(request.Type)
            {
                case MessageType.Call:
                case MessageType.Connect:
                    yield return GiveFeedback(request);
                    yield break;

                case MessageType.Text:
                    yield return GiveFeedback(request);
                    yield return RedirectMessage(request);
                    yield break;

                case MessageType.List:
                    yield return GiveFeedback(request);
                    yield return GetConnections(request, _connnection.GeyInfos());
                    yield break;

                case MessageType.Disconnect:
                case MessageType.Feedback:
                    yield break;
            }
        }

        private Message CreateMessageByType(MessageType type, string from, string to)
        {
            switch(type)
            {
                case MessageType.Call:
                case MessageType.Connect:
                case MessageType.Disconnect:
                    return new Message(type, from, to);

                case MessageType.Error:
                case MessageType.List:
                case MessageType.Text:
                    return new PayloadMessage(type, from, to);

                case MessageType.Feedback:
                    return new FeedbackMessage(from, to);

                default:
                    return null;
            }
        }
        private Message RedirectMessage(Message request)
        {
            //return new PayloadMessage(request.Type, request.To, request.From) { Payload = ((PayloadMessage)request).Payload };
            return request;
        }

        private Message GiveFeedback(Message message, FeedbackType feedback = FeedbackType.Success)
        {
            return new FeedbackMessage(_connnection.Info.Name, message.From) {Feedback = feedback};
        }

        private Message GetConnections(Message message, IEnumerable<string> connections)
        {
            var sb = new StringBuilder();
            foreach (var item in connections)
            {
                sb.Append($"{item};");
            }

            return new PayloadMessage(MessageType.List, _connnection.Info.Name, message.From) { Payload = sb.ToString().Remove(sb.Length - 1) };
        }
    }
}
