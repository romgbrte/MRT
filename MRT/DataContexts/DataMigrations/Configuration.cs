namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
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
            to avoid creating duplicate seed data.*/

            // context.Database.ExecuteSqlCommand("TRUNCATE TABLE table_name");
            // context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('table_name', RESEED, 0)");
        }
    }
}

/*
    First, enable migrations for the context:
    enable-migrations -ContextTypeName [specific db context] -MigrationDirectory DataContexts\[specific context directory]
    example:
    enable-migrations -ContextTypeName IdentityDb -MigrationsDirectory DataContexts\IdentityMigrations

    Second, create a migration:
    add-migration -ConfigurationTypeName:"[context migration namespace].Configuration" -Name:"InitialCreate"
    example:
    add-migration -ConfigurationTypeName:"MRT.DataContexts.IdentityMigrations.Configuration" -Name:"InitialCreate"

    Third, update the database:
    update-database -ConfigurationTypeName:"[context migration namespace].Configuration"
    example
    update-database -ConfigurationTypeName:"MRT.DataContexts.IdentityMigrations.Configuration"
*/
