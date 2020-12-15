using ChatService.Shared.Connections;
using ChatService.Shared.Interfaces;
using ChatService.Shared.Models;
using ChatService.Shared.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatService.Client.Client
{
    public class ChatClient
    {
        private ConnectionManager _manager;
        private readonly IDisplayMessageService _displayMessage;
        private ConnectionInfo _connectionInfo;
        public ChatClient(IDisplayMessageService displayMessage)
        {
            _displayMessage = displayMessage;
        }
        public bool IsActive => _manager != null;

        internal void Start(ConnectionInfo connectionInfo)
        {
            if (IsActive) return;
            
            _manager = new ConnectionManager(new CancellationTokenSource());

            _connectionInfo = connectionInfo;
            try
            {
                var connection = new TcpConnection(
                    new TcpClient(connectionInfo.Address, connectionInfo.Port),
                    connectionInfo,
                    _manager)
                { 
                    IsClientConnection = true 
                };

                _manager.ManageConnection(connection, _displayMessage);

                _manager.AddMessages(new List<Shared.Messages.Message>
                {
                    new Shared.Messages.Message(Shared.Messages.MessageType.Connect, _connectionInfo.Name , _connectionInfo.Name),
                 });
            }
            catch(SocketException x)
            {
                if(x.SocketErrorCode == SocketError.ConnectionRefused)
                {
                    _displayMessage?.InvokeMessage(new MessageInfo() { Type = Shared.Messages.MessageType.Error, Info = $"Сервер недоступен: ({x.Message})"}); 
                }
            }
            catch(Exception x)
            {
                _displayMessage?.InvokeMessage(new MessageInfo() { Type = Shared.Messages.MessageType.Error, Info = $"Ошибка: ({x.Message})"});
            }

        }

        internal void Stop()
        {
            _manager.CloseConnections();
            _manager = null;
        }

        internal void SendMessage(string user, string text)
        {
            if (!IsActive) return;

            _manager.AddMessages(new List<Shared.Messages.Message>
            {
                new Shared.Messages.PayloadMessage(Shared.Messages.MessageType.Text, _connectionInfo.Name , user) {Payload = text},
            });

            _displayMessage?.InvokeMessage(new MessageInfo() { Type = Shared.Messages.MessageType.Text, Info = "Message was sent" });
        }

        internal void GetRegisteredUsers()
        {
            _manager.AddMessages(new List<Shared.Messages.Message>
            {
                new Shared.Messages.Message(Shared.Messages.MessageType.List, _connectionInfo.Name, _connectionInfo.Name)
            });
        }
    }
}
