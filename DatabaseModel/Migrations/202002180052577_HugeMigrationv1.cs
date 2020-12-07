namespace DatabaseModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HugeMigrationv1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Participants", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "Sport_Id", "dbo.Sports");
            DropForeignKey("dbo.Medals", "Participant_Id", "dbo.Participants");
            DropForeignKey("dbo.OlympicSportsmen", "Participant_Id", "dbo.Participants");
            DropForeignKey("dbo.Medals", "Sportsman_Id", "dbo.OlympicSportsmen");
            DropForeignKey("dbo.OlympicSportsmen", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Sports", "OlympicSportsman_Id", "dbo.OlympicSportsmen");
            DropForeignKey("dbo.Events", "Olympiad_Id", "dbo.Olympiads");
            DropForeignKey("dbo.Olympiads", "Host_Id", "dbo.Countries");
            DropIndex("dbo.Events", new[] { "Sport_Id" });
            DropIndex("dbo.Events", new[] { "Olympiad_Id" });
            DropIndex("dbo.Participants", new[] { "Event_Id" });
            DropIndex("dbo.Medals", new[] { "Sportsman_Id" });
            DropIndex("dbo.Medals", new[] { "Participant_Id" });
            DropIndex("dbo.OlympicSportsmen", new[] { "Country_Id" });
            DropIndex("dbo.OlympicSportsmen", new[] { "Participant_Id" });
            DropIndex("dbo.Sports", new[] { "OlympicSportsman_Id" });
            DropIndex("dbo.Olympiads", new[] { "Host_Id" });
            RenameColumn(table: "dbo.Participants", name: "Event_Id", newName: "EventId");
            RenameColumn(table: "dbo.Medals", name: "Participant_Id", newName: "ParticipantId");
            RenameColumn(table: "dbo.OlympicSportsmen", name: "Participant_Id", newName: "ParticipantId");
            RenameColumn(table: "dbo.Sports", name: "OlympicSportsman_Id", newName: "OlympicSportsmanId");
            RenameColumn(table: "dbo.Events", name: "Olympiad_Id", newName: "OlympiadId");
            AddColumn("dbo.OlympicSportsmen", "PicturePath", c => c.String());
            AlterColumn("dbo.Events", "Sport_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "OlympiadId", c => c.Int(nullable: false));
            AlterColumn("dbo.Participants", "EventId", c => c.Int(nullable: false));
            AlterColumn("dbo.Medals", "Sportsman_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Medals", "ParticipantId", c => c.Int(nullable: false));
            AlterColumn("dbo.OlympicSportsmen", "Country_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.OlympicSportsmen", "ParticipantId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sports", "OlympicSportsmanId", c => c.Int(nullable: false));
            AlterColumn("dbo.Olympiads", "Host_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "OlympiadId");
            CreateIndex("dbo.Events", "Sport_Id");
            CreateIndex("dbo.Olympiads", "Host_Id");
            CreateIndex("dbo.Participants", "EventId");
            CreateIndex("dbo.Medals", "ParticipantId");
            CreateIndex("dbo.Medals", "Sportsman_Id");
            CreateIndex("dbo.OlympicSportsmen", "ParticipantId");
            CreateIndex("dbo.OlympicSportsmen", "Country_Id");
            CreateIndex("dbo.Sports", "OlympicSportsmanId");
            AddForeignKey("dbo.Participants", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "Sport_Id", "dbo.Sports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Medals", "ParticipantId", "dbo.Participants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OlympicSportsmen", "ParticipantId", "dbo.Participants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Medals", "Sportsman_Id", "dbo.OlympicSportsmen", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OlympicSportsmen", "Country_Id", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sports", "OlympicSportsmanId", "dbo.OlympicSportsmen", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "OlympiadId", "dbo.Olympiads", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Olympiads", "Host_Id", "dbo.Countries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Olympiads", "Host_Id", "dbo.Countries");
            DropForeignKey("dbo.Events", "OlympiadId", "dbo.Olympiads");
            DropForeignKey("dbo.Sports", "OlympicSportsmanId", "dbo.OlympicSportsmen");
            DropForeignKey("dbo.OlympicSportsmen", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Medals", "Sportsman_Id", "dbo.OlympicSportsmen");
            DropForeignKey("dbo.OlympicSportsmen", "ParticipantId", "dbo.Participants");
            DropForeignKey("dbo.Medals", "ParticipantId", "dbo.Participants");
            DropForeignKey("dbo.Events", "Sport_Id", "dbo.Sports");
            DropForeignKey("dbo.Participants", "EventId", "dbo.Events");
            DropIndex("dbo.Sports", new[] { "OlympicSportsmanId" });
            DropIndex("dbo.OlympicSportsmen", new[] { "Country_Id" });
            DropIndex("dbo.OlympicSportsmen", new[] { "ParticipantId" });
            DropIndex("dbo.Medals", new[] { "Sportsman_Id" });
            DropIndex("dbo.Medals", new[] { "ParticipantId" });
            DropIndex("dbo.Participants", new[] { "EventId" });
            DropIndex("dbo.Olympiads", new[] { "Host_Id" });
            DropIndex("dbo.Events", new[] { "Sport_Id" });
            DropIndex("dbo.Events", new[] { "OlympiadId" });
            AlterColumn("dbo.Olympiads", "Host_Id", c => c.Int());
            AlterColumn("dbo.Sports", "OlympicSportsmanId", c => c.Int());
            AlterColumn("dbo.OlympicSportsmen", "ParticipantId", c => c.Int());
            AlterColumn("dbo.OlympicSportsmen", "Country_Id", c => c.Int());
            AlterColumn("dbo.Medals", "ParticipantId", c => c.Int());
            AlterColumn("dbo.Medals", "Sportsman_Id", c => c.Int());
            AlterColumn("dbo.Participants", "EventId", c => c.Int());
            AlterColumn("dbo.Events", "OlympiadId", c => c.Int());
            AlterColumn("dbo.Events", "Sport_Id", c => c.Int());
            DropColumn("dbo.OlympicSportsmen", "PicturePath");
            RenameColumn(table: "dbo.Events", name: "OlympiadId", newName: "Olympiad_Id");
            RenameColumn(table: "dbo.Sports", name: "OlympicSportsmanId", newName: "OlympicSportsman_Id");
            RenameColumn(table: "dbo.OlympicSportsmen", name: "ParticipantId", newName: "Participant_Id");
            RenameColumn(table: "dbo.Medals", name: "ParticipantId", newName: "Participant_Id");
            RenameColumn(table: "dbo.Participants", name: "EventId", newName: "Event_Id");
            CreateIndex("dbo.Olympiads", "Host_Id");
            CreateIndex("dbo.Sports", "OlympicSportsman_Id");
            CreateIndex("dbo.OlympicSportsmen", "Participant_Id");
            CreateIndex("dbo.OlympicSportsmen", "Country_Id");
            CreateIndex("dbo.Medals", "Participant_Id");
            CreateIndex("dbo.Medals", "Sportsman_Id");
            CreateIndex("dbo.Participants", "Event_Id");
            CreateIndex("dbo.Events", "Olympiad_Id");
            CreateIndex("dbo.Events", "Sport_Id");
            AddForeignKey("dbo.Olympiads", "Host_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.Events", "Olympiad_Id", "dbo.Olympiads", "Id");
            AddForeignKey("dbo.Sports", "OlympicSportsman_Id", "dbo.OlympicSportsmen", "Id");
            AddForeignKey("dbo.OlympicSportsmen", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.Medals", "Sportsman_Id", "dbo.OlympicSportsmen", "Id");
            AddForeignKey("dbo.OlympicSportsmen", "Participant_Id", "dbo.Participants", "Id");
            AddForeignKey("dbo.Medals", "Participant_Id", "dbo.Participants", "Id");
            AddForeignKey("dbo.Events", "Sport_Id", "dbo.Sports", "Id");
            AddForeignKey("dbo.Participants", "Event_Id", "dbo.Events", "Id");
        }
    }
}
