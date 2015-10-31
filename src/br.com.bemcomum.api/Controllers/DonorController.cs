using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using EZServiceLocation;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace br.com.bemcomum.api.Controllers
{

    public class DonorController : ApiController
    {
        private IDonorApp _app = null;

        public DonorController()
        {
            _app = ServiceLocator.Current.GetService<IDonorApp>();
        }

        [HttpGet]
        public IEnumerable<Donor> Get()
        {
            return _app.GetAll();
        }

        [HttpGet]
        public Donor Get(Guid id)
        {
            return _app.Get(id);
        }

        [HttpPut]
        public Donor Post(Donor obj)
        {
            _app.Update(obj);
            return obj;
        }

        [AllowAnonymous]
        [HttpPut]
        public Donor Put(Donor obj)
        {
            _app.Add(obj);
            return obj;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            _app.Remove(new Donor() { Id = id });
        }
    }
}
