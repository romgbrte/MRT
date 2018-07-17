namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MRT.DataContexts.DataDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\DataMigrations";
        }

        protected override void Seed(MRT.DataContexts.DataDb context)
        {
            /*This method will be called after migrating to the latest version.

            You can use the DbSet<T>.AddOrUpdate() helper extension method 
            to avoid creating duplicate seed data.

            context.Database.ExecuteSqlCommand("TRUNCATE TABLE States");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('States', RESEED, 0)");
            */
        }
    }
}
