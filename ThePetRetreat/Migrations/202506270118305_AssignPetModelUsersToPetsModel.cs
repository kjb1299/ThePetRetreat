namespace ThePetRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignPetModelUsersToPetsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Breed = c.String(nullable: false, maxLength: 100),
                        Species = c.String(nullable: false, maxLength: 100),
                        Age = c.Int(nullable: false),
                        SpecialInstructions = c.String(maxLength: 2000),
                        FeedingFrequency = c.String(nullable: false, maxLength: 100),
                        FeedingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeedingUnit = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.PetID);
            
            CreateTable(
                "dbo.UsersToPets",
                c => new
                    {
                        UsersToPetsID = c.Guid(nullable: false),
                        UserID = c.String(maxLength: 128),
                        PetID = c.Guid(nullable: false),
                        RelationshipType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UsersToPetsID)
                .ForeignKey("dbo.Pets", t => t.PetID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.PetID);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersToPets", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersToPets", "PetID", "dbo.Pets");
            DropIndex("dbo.UsersToPets", new[] { "PetID" });
            DropIndex("dbo.UsersToPets", new[] { "UserID" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.UsersToPets");
            DropTable("dbo.Pets");
        }
    }
}
