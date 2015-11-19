using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.infra.data.config;
using MySql.Data.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace br.com.bemcomum.infra.data.context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BemComumContext : DbContext
    {
        public BemComumContext() : base("PUBCConn") {}

        public static BemComumContext GetInstance()
        {
            return new BemComumContext();
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PublicInstitution> Institutions { get; set; }
        public DbSet<Need> Needs { get; set; }
        public DbSet<Records> Records { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            modelBuilder.Configurations.Add(new DonorConfiguration());
            modelBuilder.Configurations.Add(new AdminConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new PublicInstitutionConfiguration());
            modelBuilder.Configurations.Add(new NeedConfiguration());
            modelBuilder.Configurations.Add(new RecordsConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()) 
            {
                //Todo - Check the type in a better and not fixed way
                var obj = (BaseEntity<Guid>)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    obj.Id = Guid.NewGuid();
                    obj.Save = obj.Update = DateTime.Now;
                    obj.IsActive = true;
                }

                if (entry.State == EntityState.Modified)
                {
                    obj.Update = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
