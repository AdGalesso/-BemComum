using br.com.bemcomum.domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.infra.data.config
{
    public class InstitutionConfiguration<T> : EntityTypeConfiguration<T> where T : Institution
    {
        public InstitutionConfiguration()
        {
            HasKey(k => k.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(300);

            HasRequired(a => a.Address);

            HasMany(m => m.Needs);
        }
    }
}
