namespace DatabaseModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrationv3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sportsmen", "FirstName", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Sportsmen", "FistName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sportsmen", "FistName", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Sportsmen", "FirstName");
        }
    }
}
