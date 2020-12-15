using ChatService.Shared;
using ChatService.Shared.Connections;
using ChatService.Shared.Messages;
using ChatService.Shared.Models;
using ChatService.Shared.UI;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace ChatService.Server.Server
{
    public class ChatServer
    {
        private TcpListener _listener;
        private ConnectionManager _manager;
        private IDisplayMessageService _displayMessageService;
     
        public void Start(ConnectionInfo server, IDisplayMessageService displayMessageService = default)
        {
            var cancellation = new CancellationTokenSource();
            _manager = new ConnectionManager(cancellation);

            _displayMessageService = displayMessageService;

            _listener = new TcpListener(IPAddress.Parse(server.Address), server.Port);

            _displayMessageService?.InvokeMessage(new MessageInfo() { Type = MessageType.Text, Info = "Сервер успешно запущен." });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    _listener.Start();

                    while (!cancellation.IsCancellationRequested)
                    {
                        var client = _listener.AcceptTcpClient();

                        var connection = new ConnectionInfo((IPEndPoint)client.Client.RemoteEndPoint);

                        _manager.ManageConnection(new TcpConnection(client, connection, _manager), _displayMessageService);
                    }
                }
                catch(SocketException)
                {
                    _listener = null;
                }
                
            });
            
        }

        public void Stop()
        {
            _manager.CloseConnections();
            _listener.Stop();

            _displayMessageService?.InvokeMessage(new MessageInfo() { Type = MessageType.Text, Info = "Сервер остановлен." });
        }

        public static IList<NetworkInterfaceInfo> Interfaces
        {
            get
            {
                var list = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => !n.IsReceiveOnly && n.OperationalStatus == OperationalStatus.Up);

                return list?.SelectMany(ni => ni.GetIPProperties().UnicastAddresses
                    .Select(un => new NetworkInterfaceInfo(ni.Description, un.Address)))
                    .ToList();

            }
        }
    }
}
