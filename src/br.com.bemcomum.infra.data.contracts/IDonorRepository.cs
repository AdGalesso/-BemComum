using br.com.bemcomum.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.infra.data.contracts
{
    public interface IDonorRepository : IBaseRepository<Donor>
    {
        int Count();

        IEnumerable<Donor> GetAllWithAddress();
    }
}
