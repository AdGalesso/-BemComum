using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.infra.data.context;
using br.com.bemcomum.infra.data.contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace br.com.bemcomum.infra.data.repositories
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity<Guid>
    {
        protected BemComumContext db = null;

        public void Add(T obj)
        {
            using (db = BemComumContext.GetInstance())
            {
                db.Set<T>().Add(obj);
                db.SaveChanges();
            }
        }

        public T Get(Guid id)
        {
            using (db = BemComumContext.GetInstance())
                return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            using (db = BemComumContext.GetInstance())
                return db.Set<T>().ToList();
        }

        public void Remove(T obj)
        {
            using (db = BemComumContext.GetInstance())
            {
                db.Set<T>().Remove(db.Set<T>().Find(obj.Id));
                db.SaveChanges();
            }
        }

        public void RemoveAll(IEnumerable<T> objs)
        {
            foreach (var item in objs)
                Remove(item);
        }

        public void Update(T obj)
        {
            using (db = BemComumContext.GetInstance())
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
