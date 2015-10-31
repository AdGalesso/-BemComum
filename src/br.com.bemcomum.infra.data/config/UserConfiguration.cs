using br.com.bemcomum.domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.infra.data.config
{
    public abstract class UserConfiguration<T> : EntityTypeConfiguration<T> where T : User
    {
        public UserConfiguration()
        {
            HasKey(k => k.Id);

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(255);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
