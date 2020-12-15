using ChatService.Shared.Models;
using System;
using System.IO;

namespace ChatService.Shared.Connections
{
    public class UdpConnection : Connection
    {
        public UdpConnection(
            Stream stream, 
            ConnectionInfo info,
            ConnectionManager manager) 

            : base(info, stream, manager)
        {
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }
    }
}
