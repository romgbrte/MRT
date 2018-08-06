namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStateCoverages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StateCoverages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarrierId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StateCoverages", "StateId", "dbo.States");
            DropIndex("dbo.StateCoverages", new[] { "StateId" });
            DropTable("dbo.StateCoverages");
        }
    }
}
