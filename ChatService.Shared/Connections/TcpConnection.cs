using ChatService.Shared.Interfaces;
using ChatService.Shared.Models;
using System.IO;
using System.Net.Sockets;

namespace ChatService.Shared.Connections
{
    public class TcpConnection : Connection
    {
        private readonly TcpClient _client;

        public TcpConnection(
            TcpClient client,  
            ConnectionInfo from,
            ConnectionManager manager)

            : base(from, client.GetStream(), manager)
        {
            _client = client;
        }

        public override void Close()
        {
            base.Close();
            _client.Close();
        }
    }
}
