using ChatService.Shared.Interfaces;
using ChatService.Shared.Messages;
using ChatService.Shared.Models;
using ChatService.Shared.Repositories;
using ChatService.Shared.UI;
using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ChatService.Shared.Connections
{
    public class ConnectionManager : IDisposable
    {
        readonly IRepository<ConnectionInfo, Connection> _repository;
        private readonly CancellationTokenSource _tokenSource;
        private readonly BlockingCollection<Message> _messages;
        private readonly ManualResetEventSlim _eventMessage;
        public ConnectionManager(CancellationTokenSource cancellation)
        {
            _tokenSource = cancellation;
            _repository = new ConnectionRepository();
            _messages = new BlockingCollection<Message>();
            _eventMessage = new ManualResetEventSlim(false);

            ProcessSend();
        }

        public void ManageConnection(Connection connect, IDisplayMessageService displayMessageService = default)
        {
            var connection = _repository.Add(connect.Info, connect);

            connection.ProcessRecieve(_tokenSource.Token, displayMessageService);
        }
        private void ProcessSend()
        {

            ThreadPool.QueueUserWorkItem( _ =>
            {
                try
                {
                    while (!_tokenSource.IsCancellationRequested)
                    {
                        _eventMessage.Wait(_tokenSource.Token);

                        _tokenSource.Token.ThrowIfCancellationRequested();

                        var connection = _repository.GetEntities().First();

                        foreach (var message in _messages.GetConsumingEnumerable(_tokenSource.Token))
                        {
                            if (!connection.IsClientConnection)
                                connection = _repository.Get(message.To);

                            connection?.SendAsync(message, _tokenSource.Token);
                        }

                        _eventMessage.Reset();
                    }
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            });

        }
        public void AddMessages(IEnumerable<Message> messages)
        {
            int count = 0;

            foreach (var item in messages)
            {
                _messages.TryAdd(item);

                Interlocked.Increment(ref count);
            }

            if(count > 0) 
                _eventMessage.Set();
        }
        public IEnumerable<string> GetInfos()
        {
            return _repository.GetKeys().Select(c => c.Name);
        }
        public void CloseConnections()
        {
            _tokenSource.Cancel();

            _eventMessage.Set();

            foreach (var connection in _repository.GetEntities())
            {
                connection.Close();
            }
            _repository.RemoveAll();
        }

        public void RemoveConnection(ConnectionInfo info)
        {

            _repository.Remove(info);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        ~ConnectionManager()
        {
            Dispose(false);
        }
        private void Dispose(bool disposing)
        {
            if(disposing)
            {
                GC.SuppressFinalize(this);
            }
            _eventMessage.Dispose();
            _tokenSource.Dispose();
            
        }
    }
}
