namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWCRates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WCRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarrierId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        CodeId = c.Int(nullable: false),
                        EffectiveDate = c.DateTime(nullable: false),
                        Rate = c.Single(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carriers", t => t.CarrierId, cascadeDelete: true)
                .ForeignKey("dbo.Codes", t => t.CodeId, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.CarrierId)
                .Index(t => t.StateId)
                .Index(t => t.CodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WCRates", "StateId", "dbo.States");
            DropForeignKey("dbo.WCRates", "CodeId", "dbo.Codes");
            DropForeignKey("dbo.WCRates", "CarrierId", "dbo.Carriers");
            DropIndex("dbo.WCRates", new[] { "CodeId" });
            DropIndex("dbo.WCRates", new[] { "StateId" });
            DropIndex("dbo.WCRates", new[] { "CarrierId" });
            DropTable("dbo.WCRates");
        }
    }
}
