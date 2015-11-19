using System;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.infra.data.contracts;
using br.com.bemcomum.infra.data.context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace br.com.bemcomum.infra.data.repositories
{
    public class DonorRepository : BaseRepository<Donor>, IDonorRepository
    {
        public int Count()
        {
            int total = 0;

            using (db = new BemComumContext())
                total = db.Donor.Where(d => d.IsActive).Count();

            return total;
        }

        public IEnumerable<Donor> GetAllWithAddress()
        {
            IEnumerable<Donor> donors = null;

            using (db = new BemComumContext())
                donors = db.Donor.Include(e => e.Address).Where(d => d.IsActive).ToList();

            return donors;
        }
    }
}
