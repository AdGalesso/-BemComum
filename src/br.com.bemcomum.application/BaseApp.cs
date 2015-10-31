using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;
using System;
using System.Collections.Generic;

namespace br.com.bemcomum.application
{
    public class BaseApp<T> : IBaseApp<T> where T : BaseEntity<Guid>
    {
        private IBaseService<T> _service = null;

        public BaseApp(IBaseService<T> service)
        {
            _service = service;
        }

        public void Add(T obj)
        {
            _service.Add(obj);
        }

        public T Get(Guid id)
        {
            return _service.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _service.GetAll();
        }

        public void Remove(T obj)
        {
            _service.Remove(obj);
        }

        public void RemoveAll(IEnumerable<T> objs)
        {
            _service.RemoveAll(objs);
        }

        public void Update(T obj)
        {
            _service.Update(obj);
        }
    }
}
