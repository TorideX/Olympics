namespace DatabaseModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sport_Id = c.Int(),
                        Olympiad_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sports", t => t.Sport_Id)
                .ForeignKey("dbo.Olympiads", t => t.Olympiad_Id)
                .Index(t => t.Sport_Id)
                .Index(t => t.Olympiad_Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country_Id = c.Int(),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Medals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedalType = c.Int(nullable: false),
                        Sportsman_Id = c.Int(),
                        Participant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OlympicSportsmen", t => t.Sportsman_Id)
                .ForeignKey("dbo.Participants", t => t.Participant_Id)
                .Index(t => t.Sportsman_Id)
                .Index(t => t.Participant_Id);
            
            CreateTable(
                "dbo.OlympicSportsmen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FistName = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(nullable: false, maxLength: 200),
                        BirthDate = c.DateTime(nullable: false),
                        Country_Id = c.Int(),
                        Participant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Participants", t => t.Participant_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Participant_Id);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        OlympicSportsman_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OlympicSportsmen", t => t.OlympicSportsman_Id)
                .Index(t => t.OlympicSportsman_Id);
            
            CreateTable(
                "dbo.Olympiads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Season = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 200),
                        Host_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Host_Id)
                .Index(t => t.Host_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Olympiads", "Host_Id", "dbo.Countries");
            DropForeignKey("dbo.Events", "Olympiad_Id", "dbo.Olympiads");
            DropForeignKey("dbo.Events", "Sport_Id", "dbo.Sports");
            DropForeignKey("dbo.Participants", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.OlympicSportsmen", "Participant_Id", "dbo.Participants");
            DropForeignKey("dbo.Medals", "Participant_Id", "dbo.Participants");
            DropForeignKey("dbo.Medals", "Sportsman_Id", "dbo.OlympicSportsmen");
            DropForeignKey("dbo.Sports", "OlympicSportsman_Id", "dbo.OlympicSportsmen");
            DropForeignKey("dbo.OlympicSportsmen", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Participants", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Olympiads", new[] { "Host_Id" });
            DropIndex("dbo.Sports", new[] { "OlympicSportsman_Id" });
            DropIndex("dbo.OlympicSportsmen", new[] { "Participant_Id" });
            DropIndex("dbo.OlympicSportsmen", new[] { "Country_Id" });
            DropIndex("dbo.Medals", new[] { "Participant_Id" });
            DropIndex("dbo.Medals", new[] { "Sportsman_Id" });
            DropIndex("dbo.Participants", new[] { "Event_Id" });
            DropIndex("dbo.Participants", new[] { "Country_Id" });
            DropIndex("dbo.Events", new[] { "Olympiad_Id" });
            DropIndex("dbo.Events", new[] { "Sport_Id" });
            DropTable("dbo.Olympiads");
            DropTable("dbo.Sports");
            DropTable("dbo.OlympicSportsmen");
            DropTable("dbo.Medals");
            DropTable("dbo.Participants");
            DropTable("dbo.Events");
            DropTable("dbo.Countries");
        }
    }
}
