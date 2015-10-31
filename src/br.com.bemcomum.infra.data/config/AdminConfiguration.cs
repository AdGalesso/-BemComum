using br.com.bemcomum.domain.Entities;

namespace br.com.bemcomum.infra.data.config
{
    public class AdminConfiguration : UserConfiguration<Admin>
    {
        public AdminConfiguration() 
        {
            ToTable("Admins");
        }
    }   
}
