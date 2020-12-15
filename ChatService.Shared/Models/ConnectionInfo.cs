using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ChatService.Shared.Models
{
    public class ConnectionInfo
    {
        public ConnectionInfo(string name, string address, int port)
        {
            Name = name;
            Address = address;
            Port = port;
        }
        public ConnectionInfo(IPEndPoint endPoint, string name = default)
            :this(name, endPoint.Address.ToString(), endPoint.Port)
        {

        }
        public ConnectionInfo(string connection)
        {
            var infos = connection.Split('-');
            Name = infos[0];
            Address = infos[1];
            Port = int.Parse(infos[2]);
        }
        public string Name { get; set; }
        public string Address { get; }
        public int Port { get; }
        public override string ToString()
        {
            return $"{Name}-{Address}-{Port}";
        }
        public string Key => $"{Address}:{Port}";
    }
}
