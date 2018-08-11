namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedPolicyAssignments : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PolicyAssignments (PolicyId, CarrierId, IsActive) VALUES (1, 1, 'true')");
            Sql("INSERT INTO PolicyAssignments (PolicyId, CarrierId, IsActive) VALUES (2, 2, 'true')");
            Sql("INSERT INTO PolicyAssignments (PolicyId, CarrierId, IsActive) VALUES (3, 3, 'false')");
            Sql("INSERT INTO PolicyAssignments (PolicyId, CarrierId, IsActive) VALUES (4, 3, 'true')");
            Sql("INSERT INTO PolicyAssignments (PolicyId, CarrierId, IsActive) VALUES (5, 4, 'true')");
        }
        
        public override void Down()
        {
            Sql("TRUNCATE TABLE PolicyAssignments");
            Sql("DBCC CHECKIDENT('PolicyAssignments', RESEED, 0)");
        }
    }
}
