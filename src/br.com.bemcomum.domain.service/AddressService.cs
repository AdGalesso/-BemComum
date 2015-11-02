using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;
using br.com.bemcomum.infra.data.contracts;

namespace br.com.bemcomum.domain.service
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        protected IAddressRepository _repository = null;

        public AddressService(IAddressRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
