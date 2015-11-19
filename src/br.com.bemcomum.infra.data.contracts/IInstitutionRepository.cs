using br.com.bemcomum.domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace br.com.bemcomum.infra.data.contracts
{
    public interface IInstitutionRepository : IBaseRepository<PublicInstitution>
    {
        IEnumerable<Institution> GetAllWithAddresses();

        Institution GetWithAddress(Guid id);

        void UpdateWithAddress(PublicInstitution institution);

        int Count();
    }
}
