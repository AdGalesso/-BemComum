using System.Collections.Generic;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;
using br.com.bemcomum.infra.data.contracts;

namespace br.com.bemcomum.domain.service
{
    public class DonorService : BaseService<Donor>, IDonorService
    {
        protected IDonorRepository _repository = null;

        public DonorService(IDonorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Donor> GetAllWithAddress()
        {
            return _repository.GetAllWithAddress();
        }
    }
}
