using br.com.bemcomum.domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace br.com.bemcomum.infra.data.config
{
    public class DonorConfiguration : UserConfiguration<Donor>
    {
        public DonorConfiguration()
        {
            ToTable("Donors");

            HasOptional(r => r.Address);
        }
    }
}
