namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCarriers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Carriers (Name, BaseRate, CurrentPolicyId) VALUES ('Great Big West Mutual', 4.25, 1)");
            Sql("INSERT INTO Carriers (Name, BaseRate, CurrentPolicyId) VALUES ('New Vegas Assurances', 7.77, 2)");
            Sql("INSERT INTO Carriers (Name, BaseRate, CurrentPolicyId) VALUES ('Geneva Financial Group', 2.20, 3)");
            Sql("INSERT INTO Carriers (Name, BaseRate, CurrentPolicyId) VALUES ('United Assurance Collective', 6.67, 4)");
        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE Carriers");
            Sql("DBCC CHECKIDENT('Carriers', RESEED, 0)");
        }
    }
}
