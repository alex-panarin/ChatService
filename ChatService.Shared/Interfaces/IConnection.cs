using ChatService.Shared.Messages;
using ChatService.Shared.Models;
using ChatService.Shared.UI;
using System.Threading;
using System.Threading.Tasks;

namespace ChatService.Shared.Interfaces
{
    public interface IConnection
    {
        ConnectionInfo Info { get; }
        bool IsConnected { get; }
        void Close();
        Task<int> RecieveAsync(byte[] buffer, CancellationToken cancellation);
        Task SendAsync(Message message, CancellationToken cancellation);
    }
}