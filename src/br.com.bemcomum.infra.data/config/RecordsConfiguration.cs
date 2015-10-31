using br.com.bemcomum.domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace br.com.bemcomum.infra.data.config
{
    public class RecordsConfiguration : EntityTypeConfiguration<Records>
    {
        public RecordsConfiguration()
        {
            HasKey(k => k.Id);

            HasRequired(r => r.Donor);
            HasRequired(r => r.Need);
        }
    }
}
