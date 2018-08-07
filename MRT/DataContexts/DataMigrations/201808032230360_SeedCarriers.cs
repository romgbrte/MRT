namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCarriers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('Great Big West Mutual', 4.25)");
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('New Vegas Assurances', 7.77)");
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('Geneva Financial Group', 2.20)");
            Sql("INSERT INTO Carriers (Name, BaseRate) VALUES ('United Assurance Collective', 6.67)");
        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE Carriers");
            Sql("DBCC CHECKIDENT('Carriers', RESEED, 0)");
        }
    }
}
