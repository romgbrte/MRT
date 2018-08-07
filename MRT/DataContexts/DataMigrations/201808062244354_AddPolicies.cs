namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPolicies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 30),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        PolicyTypeId = c.Byte(nullable: false),
                        FundingRate = c.Single(nullable: false),
                        CollateralRate = c.Single(nullable: false),
                        LossRate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PolicyTypes", t => t.PolicyTypeId, cascadeDelete: true)
                .Index(t => t.PolicyTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policies", "PolicyTypeId", "dbo.PolicyTypes");
            DropIndex("dbo.Policies", new[] { "PolicyTypeId" });
            DropTable("dbo.Policies");
        }
    }
}
