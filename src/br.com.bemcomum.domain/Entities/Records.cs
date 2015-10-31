using System;

namespace br.com.bemcomum.domain.Entities
{
    public abstract class Records : BaseEntity<Guid>
    {
        public Donor Donor { get; set; }

        public Need Need { get; set; }
    }
}
