using System.Data.Entity.ModelConfiguration;
using br.com.bemcomum.domain.Entities;

namespace br.com.bemcomum.infra.data.config
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("Addresses");

            HasKey(k => k.Id);

            Property(p => p.ZipCode)
                .IsRequired()
                .HasMaxLength(9);

            Property(p => p.City)
                .IsOptional()
                .HasMaxLength(100);

            Property(p => p.State)
                .IsOptional()
                .HasMaxLength(50);

            Property(p => p.Street)
                .IsOptional()
                .HasMaxLength(100);

            Property(p => p.Number)
               .IsOptional()
               .HasMaxLength(10);

            Property(p => p.Latitude)
               .IsOptional()
               .HasMaxLength(20);

            Property(p => p.Longitude)
               .IsOptional()
               .HasMaxLength(20);

            Property(p => p.Phone)
              .IsOptional()
              .HasMaxLength(20);

            Property(p => p.Mobile)
              .IsOptional()
              .HasMaxLength(20);
        }
    }
}
