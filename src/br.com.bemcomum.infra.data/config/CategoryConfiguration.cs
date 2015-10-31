using br.com.bemcomum.domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.bemcomum.infra.data.config
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");

            HasKey(k => k.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(p => p.Description)
                .HasMaxLength(1000);
        }
    }
}
