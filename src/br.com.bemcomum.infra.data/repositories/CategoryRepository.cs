using System;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.infra.data.contracts;
using br.com.bemcomum.infra.data.context;
using System.Linq;

namespace br.com.bemcomum.infra.data.repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public int Count()
        {
            int total = 0;

            using (db = new BemComumContext())
            {
                total = db.Categories.Where(c => c.IsActive == true).Count();
            }

            return total;
        }
    }
}
