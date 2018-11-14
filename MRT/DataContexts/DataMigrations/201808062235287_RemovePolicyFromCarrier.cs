namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePolicyFromCarrier : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Carriers", "CurrentPolicyId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Carriers", "CurrentPolicyId", c => c.Int());
        }
    }
}
