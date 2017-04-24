using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IkeCode.Data
{
    public class Repository<T> : IRepository<T>
        where T : IcModel
    {
        protected readonly DbContext context;
        protected DbSet<T> entities;

        public Repository(DbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> Get(string[] includes, int offset, int limit, string order)
        {
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset", "offset parameter must to be greater than or equal to 0");

            if (limit > 100)
                throw new ArgumentOutOfRangeException("limit", "limit parameter must to be lower than or equal to 100");

            if (includes != null)
                foreach (var include in includes)
                {
                    entities.Include(include);
                }

            if (string.IsNullOrWhiteSpace(order))
            {
                entities.OrderBy(i => i.Id);
            }

            var result = entities.Skip(offset).Take(limit);
            return result;
        }

        public T Get(int id, string[] includes = null)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException("key", "key parameter must to be greater than 0");

            if (includes != null)
                foreach (var include in includes)
                {
                    entities.Include(include);
                }


            var query = entities.FirstOrDefault(i => i.Id == id);

            return query;
        }

        protected virtual void OnRemove(T entity)
        {
            entities.Remove(entity);
        }

        public bool Remove(int key)
        {
            if (key < 1)
                throw new ArgumentOutOfRangeException("key", "key parameter must to be greater than 0");

            var entity = this.Get(key);
            var result = entity != null;

            if (result)
            {
                OnRemove(entity);

                context.SaveChanges();
            }

            return result;
        }

        public void Upsert(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (item.Id == 0)
            {
                item.CreatedAt = DateTime.UtcNow;
                entities.Add(item);
            }
            else
            {
                entities.Update(item);
            }

            context.SaveChanges();
        }
    }
}
