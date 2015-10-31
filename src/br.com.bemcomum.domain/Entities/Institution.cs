using br.com.bemcomum.domain.Entities.Enum;
using System;
using System.Collections.Generic;

namespace br.com.bemcomum.domain.Entities
{
    public abstract class Institution : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public string Operation { get; set; }

        public Address Address { get; set; }

        public string Photo { get; set; }

        public InstitutionStatus Status { get; set; }

        public ICollection<Need> Needs { get; set; }
    }
}
