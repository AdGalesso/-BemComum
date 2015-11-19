using br.com.bemcomum.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.domain.service.contracts
{
    public interface IInstitutionService : IBaseService<PublicInstitution>
    {
        int Count();

        IEnumerable<Institution> GetAllWithAddresses();
    }
}
