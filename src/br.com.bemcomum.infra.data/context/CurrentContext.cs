using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace br.com.bemcomum.infra.data.context
{
    public class CurrentContext : DbContext
    {
        public CurrentContext() : base("PUBCConn") {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Properties()
            //.Where(p => p.Name == p.ReflectedType.Name + "Id")
            //.Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()) 
            {               
                //Todo - Check the type in a better not fixed way

                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity.GetType() == typeof(IEntity<>))
                        ((IEntity<Guid>)entry.Entity).Save = DateTime.Now;
                    else if (entry.Entity is IEntity<int>)
                        ((IEntity<int>)entry.Entity).Save = DateTime.Now;
                    else if (entry.Entity is IEntity<decimal>)
                        ((IEntity<decimal>)entry.Entity).Save = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is IEntity<Guid>)
                        ((IEntity<Guid>)entry.Entity).Update = DateTime.Now;
                    else if (entry.Entity is IEntity<int>)
                        ((IEntity<int>)entry.Entity).Update = DateTime.Now;
                    else if (entry.Entity is IEntity<decimal>)
                        ((IEntity<decimal>)entry.Entity).Update = DateTime.Now;
                }

            }

            return base.SaveChanges();
        }
    }
}
