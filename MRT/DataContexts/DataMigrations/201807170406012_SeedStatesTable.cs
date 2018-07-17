namespace MRT.DataContexts.DataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedStatesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Alabama', 'AL')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Alaska', 'AK')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Arizona', 'AZ')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Arkansas', 'AR')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('California', 'CA')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Colorado', 'CO')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Connecticut', 'CT')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('District of Columbia', 'DC')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Delaware', 'DE')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Florida', 'FL')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Georgia', 'GA')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Hawaii', 'HI')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Idaho', 'ID')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Illinois', 'IL')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Indiana', 'IN')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Iowa', 'IA')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Kansas', 'KS')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Kentucky', 'KY')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Louisiana', 'LA')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Maine', 'ME')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Maryland', 'MD')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Massachusetts', 'MA')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Michigan', 'MI')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Minnesota', 'MN')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Mississippi', 'MS')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Missouri', 'MO')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Montana', 'MT')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Nebraska', 'NE')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Nevada', 'NV')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('New Hampshire', 'NH')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('New Jersey', 'NJ')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('New Mexico', 'NM')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('New York', 'NY')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('North Carolina', 'NC')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('North Dakota', 'ND')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Ohio', 'OH')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Oklahoma', 'OK')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Oregon', 'OR')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Pennsylvania', 'PA')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Rhode Island', 'RI')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('South Carolina', 'SC')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('South Dakota', 'SD')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Tennessee', 'TN')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Texas', 'TX')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Utah', 'UT')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Vermont', 'VT')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Virginia', 'VA')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Washington', 'WA')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('West Virginia', 'WV')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Wisconsin', 'WI')");
            Sql("INSERT INTO States (Name, Abbreviation) VALUES ('Wyoming', 'WY')");
        }
        
        public override void Down()
        {
        }
    }
}
