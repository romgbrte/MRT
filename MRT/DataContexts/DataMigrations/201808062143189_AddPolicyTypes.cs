namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPolicyTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PolicyTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PolicyTypes");
        }
    }
}
