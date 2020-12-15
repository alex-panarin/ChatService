using System.Net;

namespace ChatService.Shared
{
    public class NetworkInterfaceInfo
    {
        public NetworkInterfaceInfo(string description, IPAddress adsress)
        {
            Address = adsress;
            Description = $"{description}:{Address}";
        }
        public string Description { get; }
        public IPAddress Address { get; }
    }
}