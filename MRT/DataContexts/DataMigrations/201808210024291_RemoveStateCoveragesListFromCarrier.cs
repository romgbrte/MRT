namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStateCoveragesListFromCarrier : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StateCoverages", "CarrierId", "dbo.Carriers");
            DropIndex("dbo.StateCoverages", new[] { "CarrierId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.StateCoverages", "CarrierId");
            AddForeignKey("dbo.StateCoverages", "CarrierId", "dbo.Carriers", "Id", cascadeDelete: true);
        }
    }
}
