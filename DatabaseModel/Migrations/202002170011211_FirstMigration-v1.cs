namespace DatabaseModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrationv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sports", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sports", "ImagePath");
        }
    }
}
