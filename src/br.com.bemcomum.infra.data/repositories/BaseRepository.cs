using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.infra.data.context;
using br.com.bemcomum.infra.data.contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace br.com.bemcomum.infra.data.repositories
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity<Guid>
    {
        protected BemComumContext db = BemComumContext.GetInstance();
        private DbSet<T> _dbSet = null;

        public BaseRepository()
        {
            _dbSet = db.Set<T>();
        }

        public void Add(T obj)
        {
            _dbSet.Add(obj);
            db.SaveChanges();
        }

        public T Get(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(T obj)
        {
            _dbSet.Remove(obj);
            db.SaveChanges();
        }

        public void RemoveAll(IEnumerable<T> objs)
        {
            foreach (var item in objs)
                _dbSet.Remove(item);

            db.SaveChanges();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
