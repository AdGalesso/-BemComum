using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;
using br.com.bemcomum.infra.data.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.domain.service
{
    public class InstitutionService : BaseService<PublicInstitution>, IInstitutionService
    {
        IInstitutionRepository _repository = null;

        public InstitutionService(IInstitutionRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public int Count()
        {
            return _repository.Count();
        }

        public override PublicInstitution Get(Guid id)
        {
            return (PublicInstitution)_repository.GetWithAddress(id);
        }

        public IEnumerable<Institution> GetAllWithAddresses()
        {
            return _repository.GetAllWithAddresses();
        }

        public override void Update(PublicInstitution obj)
        {
            _repository.UpdateWithAddress(obj);
        }
    }
}
