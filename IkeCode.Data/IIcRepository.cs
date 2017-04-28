using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkeCode.Data
{
    public interface IIcBaseRepository<TEntity, TKey>
    {
        IEnumerable<TEntity> Get(string[] includes, int offset, int limit, string order);
        TEntity Get(TKey key, string[] includes);
        void Upsert(TEntity item);
        bool Remove(TKey key);
    }

    public interface IIcRepository<TEntity, TContext> : IIcBaseRepository<TEntity, int>
        where TEntity : IcBaseModel
        where TContext : DbContext
    {
    }
}
