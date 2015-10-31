using System;

namespace br.com.bemcomum.domain.Entities
{
    public abstract class User : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Photo { get; }

        public abstract void Login();

        public void GetPhoto()
        {

        }
    }
}
