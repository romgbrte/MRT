namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStateCoverages : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO StateCoverages (CarrierId, StateId) VALUES (1, 3)");
            Sql("INSERT INTO StateCoverages (CarrierId, StateId) VALUES (1, 9)");
            Sql("INSERT INTO StateCoverages (CarrierId, StateId) VALUES (2, 31)");
            Sql("INSERT INTO StateCoverages (CarrierId, StateId) VALUES (2, 44)");
            Sql("INSERT INTO StateCoverages (CarrierId, StateId) VALUES (3, 10)");
            Sql("INSERT INTO StateCoverages (CarrierId, StateId) VALUES (3, 17)");
            Sql("INSERT INTO StateCoverages (CarrierId, StateId) VALUES (3, 43)");
            Sql("INSERT INTO StateCoverages (CarrierId, StateId) VALUES (4, 31)");
            Sql("INSERT INTO StateCoverages (CarrierId, StateId) VALUES (4, 10)");
        }
        
        public override void Down()
        {
            Sql("TRUNCATE TABLE StateCoverages");
            Sql("DBCC CHECKIDENT('StateCoverages', RESEED, 0)");
        }
    }
}
