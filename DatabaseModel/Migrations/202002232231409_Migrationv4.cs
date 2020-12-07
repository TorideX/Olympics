namespace DatabaseModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrationv4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sports", "Season", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sports", "Season");
        }
    }
}
