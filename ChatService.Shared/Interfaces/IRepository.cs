using ChatService.Shared.Connections;
using System;
using System.Collections.Generic;

namespace ChatService.Shared.Interfaces
{
    public interface IRepository<TKey, TEntity>
    {
        TEntity Get(TKey key);
        TEntity Add(TKey key, TEntity value);
        void RemoveAll();
        IEnumerable<TEntity> GetEntities();
        IEnumerable<TKey> GetKeys();
        void Remove(TKey key);
        TEntity Get(string keyName);
        

    }
}