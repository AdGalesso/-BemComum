using System;

namespace br.com.bemcomum.domain.Entities
{
    public class Need : BaseEntity<Guid>
    {
        public Category Category { get; set; }

        public string Observation { get; set; }
    }
}
