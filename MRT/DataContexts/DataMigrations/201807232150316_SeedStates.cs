namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.IO;
    using System.Data.Entity.Migrations;

    public partial class SeedStates : DbMigration
    {
        public override void Up()
        {
            // Remember to set the target .sql file as an Embedded Resource via its Properties
            var sqlPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin")),
                "SeedData",
                @"dbo.States.data.sql"
            );
            Sql(File.ReadAllText(sqlPath));
        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE States");
            Sql("DBCC CHECKIDENT('States', RESEED, 0)");
        }
    }
}
