namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPolicyTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PolicyTypes (Id, Name) VALUES (0, 'Master')");
            Sql("INSERT INTO PolicyTypes (Id, Name) VALUES (1, 'MCP')");
            Sql("INSERT INTO PolicyTypes (Id, Name) VALUES (2, 'Direct')");
            Sql("INSERT INTO PolicyTypes (Id, Name) VALUES (3, 'Other')");
        }
        
        public override void Down()
        {
            Sql("TRUNCATE TABLE PolicyTypes");
            Sql("DBCC CHECKIDENT('PolicyTypes', RESEED, 0)");
        }
    }
}
