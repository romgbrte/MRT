namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPolicyAssignments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PolicyAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PolicyId = c.Int(nullable: false),
                        CarrierId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carriers", t => t.CarrierId, cascadeDelete: true)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.PolicyId)
                .Index(t => t.CarrierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PolicyAssignments", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.PolicyAssignments", "CarrierId", "dbo.Carriers");
            DropIndex("dbo.PolicyAssignments", new[] { "CarrierId" });
            DropIndex("dbo.PolicyAssignments", new[] { "PolicyId" });
            DropTable("dbo.PolicyAssignments");
        }
    }
}
