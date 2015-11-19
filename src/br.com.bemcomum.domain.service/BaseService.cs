using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;
using br.com.bemcomum.infra.data.contracts;
using System;
using System.Collections.Generic;

namespace br.com.bemcomum.domain.service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity<Guid>
    {
        private IBaseRepository<T> _repository = null;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Add(T obj)
        {
            _repository.Add(obj);
        }

        public virtual T Get(Guid id)
        {
            return _repository.Get(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Remove(T obj)
        {
            _repository.Remove(obj);
        }

        public virtual void RemoveAll(IEnumerable<T> objs)
        {
            _repository.RemoveAll(objs);
        }

        public virtual void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
