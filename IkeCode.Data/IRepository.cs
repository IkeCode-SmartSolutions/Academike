using System;
using System.Collections.Generic;
using System.Text;

namespace IkeCode.Data
{
    public interface IBaseRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> Get(string[] includes, int offset, int limit, string order);
        TEntity Get(TKey key, string[] includes);
        void Upsert(TEntity item);
        bool Remove(TKey key);
    }

    public interface IRepository<TEntity> : IBaseRepository<TEntity, int>
        where TEntity : IcModel
    {
    }
}
