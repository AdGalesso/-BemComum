using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using EZServiceLocation;
using System.Web.Http;

namespace br.com.bemcomum.api.Controllers
{
    public class AddressController : ApiController
    {
        private IAddressApp _app = null;

        public AddressController()
        {
            _app = ServiceLocator.Current.GetService<IAddressApp>();
        }

        [HttpPost]
        public Address Post(Address obj)
        {
            _app.Update(obj);
            return obj;
        }

        [HttpPut]
        public Address Put(Address obj)
        {
            _app.Add(obj);
            return obj;
        }
    }
}
