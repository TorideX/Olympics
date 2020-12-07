namespace DatabaseModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrationv31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Olympiads", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Olympiads", "ImagePath");
        }
    }
}
