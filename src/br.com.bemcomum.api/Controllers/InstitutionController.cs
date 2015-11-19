using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using EZServiceLocation;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace br.com.bemcomum.api.Controllers
{
    public class InstitutionController : ApiController
    {
        private IInstitutionApp _app = null;

        public InstitutionController()
        {
            _app = ServiceLocator.Current.GetService<IInstitutionApp>();
        }

        [HttpGet]
        public PublicInstitution Get(Guid id)
        {
            return _app.Get(id);
        }

        [HttpGet]
        public IEnumerable<PublicInstitution> GetAll()
        {
            return _app.GetAll();
        }

        [HttpPost]
        public Institution Post(PublicInstitution obj)
        {
            _app.Update(obj);
            return obj;
        }

        [HttpPut]
        public Institution Put(PublicInstitution obj)
        {
            _app.Add(obj);
            return obj;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            _app.Remove(new PublicInstitution() { Id = id });
        }
    }
}
