using br.com.bemcomum.infra.data.context;
using MySql.Data.Entity;
using System.Data.Entity.Migrations;

namespace br.com.bemcomum.infra.data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BemComumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator()); 
        }

        protected override void Seed(BemComumContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
