using br.com.bemcomum.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.domain.Entities
{
    public abstract class Need : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Category Category { get; set; }

        public string Observation { get; set; }

        public bool IsActive { get; set; }

        public DateTime Save { get; set; }

        public DateTime Update { get; set; }
    }
}
