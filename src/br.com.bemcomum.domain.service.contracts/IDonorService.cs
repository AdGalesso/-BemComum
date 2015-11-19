using br.com.bemcomum.domain.Entities;
using System.Collections.Generic;

namespace br.com.bemcomum.domain.service.contracts
{
    public interface IDonorService : IBaseService<Donor>
    {
        IEnumerable<Donor> GetAllWithAddress();
    }
}
