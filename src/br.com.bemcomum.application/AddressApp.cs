using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.application
{
    public class AddressApp : BaseApp<Address>, IAddressApp
    {
        protected IAddressService _service = null;

        public AddressApp(IAddressService service) 
            : base(service)
        {
            _service = service;
        }
    }
}
