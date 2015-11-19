using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.Entities.Enum;
using br.com.bemcomum.infra.data.context;
using br.com.bemcomum.infra.data.contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace br.com.bemcomum.infra.data.repositories
{
    public class InstitutionRepository : BaseRepository<PublicInstitution>, IInstitutionRepository
    {
        public Institution GetWithAddress(Guid id)
        {
            using (db = BemComumContext.GetInstance())
                return db.Institutions.Include(i => i.Address).FirstOrDefault(i => i.Id == id);
        }

        public void UpdateWithAddress(PublicInstitution institution)
        {
            using (db = BemComumContext.GetInstance())
            {
                db.Entry(institution).State = EntityState.Modified;
                db.Entry(institution.Address).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IEnumerable<Institution> GetAllWithAddresses()
        {
            using (db = BemComumContext.GetInstance())
                return db.Institutions.Include(i => i.Address).Where(i => i.IsActive && i.Status == InstitutionStatus.Approved).ToList();
        }

        public int Count()
        {
            var total = 0;

            using (db = BemComumContext.GetInstance())
                total = db.Institutions.Where(i => i.IsActive && i.Status == InstitutionStatus.Approved).Count();

            return total;
        }
    }
}
