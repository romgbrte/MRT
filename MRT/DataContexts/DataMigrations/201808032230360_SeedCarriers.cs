namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.IO;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCarriers : DbMigration
    {
        public override void Up()
        {
            // Remember to set the target .sql file as an Embedded Resource via its Properties
            var sqlPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin")),
                "SeedData",
                @"dbo.Carriers.data.sql"
            );
            Sql(File.ReadAllText(sqlPath));

            /*
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('Great Big West Mutual', 4.25)");
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('New Vegas Assurances', 7.77)");
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('Geneva Financial Group', 2.20)");
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('United Assurance Collective', 6.67)");
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('Atlas Global Union', 7.65)");
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('Southwest Coverage Specialists', 11.75)");
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('Firefox Nationwide', 5.425)");
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('Northeast Coverage Unlimited', 9.5)");
            */
        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE Carriers");
            Sql("DBCC CHECKIDENT('Carriers', RESEED, 0)");
        }
    }
}
