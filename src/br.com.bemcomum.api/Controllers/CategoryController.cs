using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using EZServiceLocation;
using System;
using System.Collections;
using System.Web.Http;

namespace br.com.bemcomum.api.Controllers
{
    public class CategoryController : ApiController
    {
        ICategoryApp _app = null;

        public CategoryController()
        {
            _app = ServiceLocator.Current.GetService<ICategoryApp>();
        }

        [HttpGet]
        public IEnumerable GetAll()
        {
            return _app.GetAll();
        }

        [HttpPost]
        public Category Post(Category obj)
        {
            _app.Update(obj);
            return obj;
        }

        [HttpPut]
        public Category Put(Category obj)
        {
            _app.Add(obj);
            return obj;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            _app.Remove(new Category() { Id = id });
        }
    }
}
