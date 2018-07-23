namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.IO;
    using System.Data.Entity.Migrations;

    public partial class SeedCodes : DbMigration
    {
        public override void Up()
        {
            // Remember to set the target .sql file as an Embedded Resource via its Properties
            var sqlPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin")),
                "SeedData",
                @"dbo.Codes.data.sql"
            );
            Sql(File.ReadAllText(sqlPath));
        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE Codes");
            Sql("DBCC CHECKIDENT('Codes', RESEED, 0)");
        }
    }
}
