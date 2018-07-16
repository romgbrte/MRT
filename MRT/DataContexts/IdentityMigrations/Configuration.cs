namespace MRT.DataContexts.IdentityMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MRT.DataContexts.IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\IdentityMigrations";
        }

        protected override void Seed(MRT.DataContexts.IdentityDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

/*
    First, enable migrations for the context:
    enable-migrations -ContextTypeName [specific db context] -MigrationDirectory DataContexts\[specific context directory]
    example:
    enable-migrations -ContextTypeName IdentityDb -MigrationsDirectory DataContexts\IdentityMigrations

    Second, create a migration:
    add-migration -ConfigurationTypeName [context migration namespace].Configuration "InitialCreate"
    example:
    add-migration -ConfigurationTypeName MRT.DataContexts.IdentityMigrations.Configuration "InitialCreate"

    Third, update the database:
    update-database -ConfigurationTypeName [context migration namespace].Configuration
    example
    update-database -ConfigurationTypeName MRT.DataContexts.IdentityMigrations.Configuration
*/
