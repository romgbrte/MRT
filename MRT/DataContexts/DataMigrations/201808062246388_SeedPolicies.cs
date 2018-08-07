namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPolicies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Policies (Number, StartDate, EndDate, PolicyTypeId, FundingRate, CollateralRate, LossRate) VALUES ('GBWM-18-001', '4/1/18', '3/30/19', 1, 4.75, 7.00, 6.25)");
            Sql("INSERT INTO Policies (Number, StartDate, EndDate, PolicyTypeId, FundingRate, CollateralRate, LossRate) VALUES ('NVA-18-001', '4/1/18', '3/30/19', 2, 3.50, 4.50, 5.50)");
            Sql("INSERT INTO Policies (Number, StartDate, EndDate, PolicyTypeId, FundingRate, CollateralRate, LossRate) VALUES ('GFG-17-001', '10/1/17', '4/1/18', 0, 2.25, 5.00, 4.00)");
            Sql("INSERT INTO Policies (Number, StartDate, EndDate, PolicyTypeId, FundingRate, CollateralRate, LossRate) VALUES ('GFG-18-002', '4/1/18', '3/30/19', 0, 2.25, 5.00, 4.25)");
            Sql("INSERT INTO Policies (Number, StartDate, EndDate, PolicyTypeId, FundingRate, CollateralRate, LossRate) VALUES ('UAC-18-001', '6/1/18', '3/30/19', 3, 5.50, 8.25, 5.75)");
        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE Policies");
            Sql("DBCC CHECKIDENT('Policies', RESEED, 0)");
        }
    }
}
