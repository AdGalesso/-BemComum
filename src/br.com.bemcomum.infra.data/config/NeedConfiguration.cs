using br.com.bemcomum.domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace br.com.bemcomum.infra.data.config
{
    public class NeedConfiguration : EntityTypeConfiguration<Need>
    {
        public NeedConfiguration()
        {
            ToTable("Needs");

            HasKey(k => k.Id);

            Property(p => p.Observation)
                .IsRequired()
                .HasMaxLength(500);

            HasRequired(r => r.Category);
        }
    }
}
