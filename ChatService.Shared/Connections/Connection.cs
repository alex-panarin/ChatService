using ChatService.Shared.Interfaces;
using ChatService.Shared.Messages;
using ChatService.Shared.Models;
using ChatService.Shared.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ChatService.Shared.Connections
{
    public abstract class Connection : IConnection
    {
        private readonly Stream _stream;
        private readonly ConnectionManager _manager;
        private readonly MessageProcessor _processor;
        private CancellationTokenSource _cancellation;

        public ConnectionInfo Info { get; private set; }

        public Connection(
            ConnectionInfo info,
            Stream stream,
            ConnectionManager manager)
        {
            _stream = stream;
            _manager = manager;
            Info = info;

            _processor = new MessageProcessor(this);
        }

        public bool IsConnected => !string.IsNullOrEmpty(Info.Name);
        public bool IsClientConnection { get; set; } = false;
        internal IEnumerable<string> GeyInfos()
        {
            return _manager.GetInfos();
        }
        public Task SendAsync(Message message, CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<bool>();

            try
            {
                var buffer = message.ToByteArray();

                _stream.BeginWrite(buffer, 0, buffer.Length, iar =>
                {
                    try
                    {
                        cancellation.ThrowIfCancellationRequested();

                        _stream.EndWrite(iar);

                    }
                    catch (Exception exc)
                    {
                        tcs.TrySetException(exc);
                    }
                },
                default);
            }
            catch
            {
                throw;
            }

            return tcs.Task;
        }
        public Task<int> RecieveAsync(byte[] buffer, CancellationToken cancellation)
        {
            var tcs = new TaskCompletionSource<int>();
            try
            {
                _stream.BeginRead(buffer, 0, buffer.Length, iar =>
                {
                    try
                    {
                        cancellation.ThrowIfCancellationRequested();

                        tcs.TrySetResult(_stream.EndRead(iar));
                    }
                    catch (Exception exc)
                    {
                        tcs.TrySetException(exc);
                    }

                }, null);

            }
            catch
            {
                throw;
            }
            return tcs.Task;
        }
        public virtual void Close()
        {
            _cancellation?.Cancel();
            _cancellation?.Dispose();
        }
        internal void ProcessRecieve(CancellationToken cancellation, IDisplayMessageService displayMessageService = default)
        {
            _cancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellation);

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    while (!_cancellation.IsCancellationRequested)
                    {
                        _cancellation.Token.ThrowIfCancellationRequested();

                        byte[] buffer = new byte[4096];

                        var size = RecieveAsync(buffer, _cancellation.Token);

                        var requests = _processor.ProcessRequest(buffer, size.Result);
                       
                        foreach (var request in requests)
                        {
                            if (request == null)
                            {
                                // Should be server stoped or connection was closed by client
                                displayMessageService?.InvokeMessage(new MessageInfo() { Type = MessageType.Disconnect, Info = Info.Name });
                                
                                throw new OperationCanceledException();
                            }

                            if (request.Type == MessageType.Connect)
                            {
                                if (IsConnected) continue;

                                Info.Name = request.From;
                                displayMessageService?.InvokeMessage(new MessageInfo() { Type = request.Type, Info = request.From });
                            }

                            if (!IsClientConnection)
                            {
                                var response = _processor.ProcessResponce(request);

                                _manager.AddMessages(response);
                            }
                            else
                            {
                                string info = request.From;

                                if(request is PayloadMessage pm)
                                {
                                    info = pm.Payload;
                                }

                                if(request is FeedbackMessage fm)
                                {
                                    info = fm.Feedback.ToString();
                                }

                                displayMessageService?.InvokeMessage(new MessageInfo() { Type = request.Type, Info = info});
                            }
                        }
                    }
                }
                catch (AggregateException)
                {
                    return;
                }
                catch (OperationCanceledException)
                {
                    _manager.RemoveConnection(Info);
                    Close();
                    return;
                }
            });
        }

    }
}
