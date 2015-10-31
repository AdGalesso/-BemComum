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

        public void Add(T obj)
        {
            _repository.Add(obj);
        }

        public T Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(T obj)
        {
            _repository.Remove(obj);
        }

        public void RemoveAll(IEnumerable<T> objs)
        {
            _repository.RemoveAll(objs);
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
