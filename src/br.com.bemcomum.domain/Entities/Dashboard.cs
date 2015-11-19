using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.domain.Entities
{
    public class Dashboard
    {
        public IEnumerable<Donor> Donors { get; set; }

        public IEnumerable<Institution> Institutions { get; set; }

        public int InstitutionsCount { get { return Institutions.Count(); } }

        public int DonorsCount { get { return Donors.Count(); } }

        public int CategoriesCount { get; set; }
    }
}
