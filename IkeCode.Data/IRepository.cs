using System;
using System.Collections.Generic;
using System.Text;

namespace IkeCode.Data
{
    public interface IBaseRepository<TEntity, TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="includes">(Nullable)</param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="order">(Nullable)</param>
        /// <returns></returns>
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
