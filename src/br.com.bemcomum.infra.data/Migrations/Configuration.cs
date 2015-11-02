using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.infra.data.context;
using MySql.Data.Entity;
using System;
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
            context.Admin.AddOrUpdate(p => new { p.Email }, new Admin() {
                Name = "Adriano Galesso Alves",
                Email = "adrianogalesso@outlook.com",
                Password = "1234"
            });

            context.Admin.AddOrUpdate(p => new { p.Email }, new Admin() {
                Name = "Andrea D'Alcantara",
                Email = "masgrela@gmail.com",
                Password = "1234"
            });

            context.Admin.AddOrUpdate(p => new { p.Email }, new Admin() {
                Name = "Marina Alvarez",
                Email = "marina.alvarez@rakuten.com.br",
                Password = "1234"
            });
        }
    }
}
