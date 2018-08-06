namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStateCoveragesTypeInCarrier : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.StateCoverages", "CarrierId");
            AddForeignKey("dbo.StateCoverages", "CarrierId", "dbo.Carriers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StateCoverages", "CarrierId", "dbo.Carriers");
            DropIndex("dbo.StateCoverages", new[] { "CarrierId" });
        }
    }
}
