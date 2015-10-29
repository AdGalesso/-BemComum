using br.com.bemcomum.domain.Interfaces;
using System;

namespace br.com.bemcomum.domain.Entities
{
    public abstract class User : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Photo { get; set; }

        public bool IsActive { get; set; }

        public DateTime Save { get; set; }

        public DateTime Update { get; set; }
    }
}
