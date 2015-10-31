using br.com.bemcomum.domain.Entities;
using System;
using System.Collections.Generic;

namespace br.com.bemcomum.domain.service.contracts
{
    public interface IBaseService<T> where T : BaseEntity<Guid>
    {
        void Add(T obj);

        T Get(Guid id);

        IEnumerable<T> GetAll();

        void Update(T obj);

        void Remove(T obj);

        void RemoveAll(IEnumerable<T> objs);
    }
}
