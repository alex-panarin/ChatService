using ChatService.Shared.Connections;
using ChatService.Shared.Interfaces;
using ChatService.Shared.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatService.Shared.Repositories
{
    public class ConnectionRepository : IRepository<ConnectionInfo, Connection>
    {
        readonly ConcurrentDictionary<ConnectionInfo, Connection> _repos;
        public ConnectionRepository()
        {
            _repos = new ConcurrentDictionary<ConnectionInfo, Connection>();
        }
        
        public IEnumerable<Connection> GetEntities()
        {
            return _repos.Values.ToList();
        }

        public IEnumerable<ConnectionInfo> GetKeys()
        {
            return _repos.Keys.ToList();
        }

        public Connection Get(string keyName)
        {
            return _repos.ToArray()
                .First(k => k.Key.Name == keyName)
                .Value;
        }

        public Connection Get(ConnectionInfo key)
        {
            return _repos.GetOrAdd(key, k =>  null);
        }
        public Connection Add(ConnectionInfo key, Connection connection)
        {
            return _repos.AddOrUpdate(key, connection, (k, v) => v);
        }

        public void Remove(ConnectionInfo key)
        {
            _repos.TryRemove(key, out _);
        }

        public void RemoveAll()
        {
            _repos.Clear();
        }

    }
}
