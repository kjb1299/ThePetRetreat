namespace ThePetRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignBookingPetModelBookingModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersToPets", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.UsersToPets", new[] { "UserID" });
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Guid(nullable: false),
                        BookingCreatedByUserID = c.String(nullable: false, maxLength: 128),
                        CheckedInByUserID = c.String(maxLength: 128),
                        CheckedOutByUserID = c.String(maxLength: 128),
                        DateTimeCreated = c.DateTime(nullable: false),
                        BookingStatus = c.String(nullable: false, maxLength: 50),
                        DateTimeCheckedIn = c.DateTime(),
                        DateTimeCheckedOut = c.DateTime(),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.AspNetUsers", t => t.BookingCreatedByUserID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CheckedInByUserID)
                .ForeignKey("dbo.AspNetUsers", t => t.CheckedOutByUserID)
                .Index(t => t.BookingCreatedByUserID)
                .Index(t => t.CheckedInByUserID)
                .Index(t => t.CheckedOutByUserID);
            
            CreateTable(
                "dbo.BookingPets",
                c => new
                    {
                        BookingPetID = c.Guid(nullable: false),
                        BookingID = c.Guid(nullable: false),
                        PetID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BookingPetID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.PetID, cascadeDelete: true)
                .Index(t => t.BookingID)
                .Index(t => t.PetID);
            
            AlterColumn("dbo.UsersToPets", "UserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UsersToPets", "UserID");
            AddForeignKey("dbo.UsersToPets", "UserID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersToPets", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookingPets", "PetID", "dbo.Pets");
            DropForeignKey("dbo.BookingPets", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "CheckedOutByUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bookings", "CheckedInByUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bookings", "BookingCreatedByUserID", "dbo.AspNetUsers");
            DropIndex("dbo.BookingPets", new[] { "PetID" });
            DropIndex("dbo.BookingPets", new[] { "BookingID" });
            DropIndex("dbo.UsersToPets", new[] { "UserID" });
            DropIndex("dbo.Bookings", new[] { "CheckedOutByUserID" });
            DropIndex("dbo.Bookings", new[] { "CheckedInByUserID" });
            DropIndex("dbo.Bookings", new[] { "BookingCreatedByUserID" });
            AlterColumn("dbo.UsersToPets", "UserID", c => c.String(maxLength: 128));
            DropTable("dbo.BookingPets");
            DropTable("dbo.Bookings");
            CreateIndex("dbo.UsersToPets", "UserID");
            AddForeignKey("dbo.UsersToPets", "UserID", "dbo.AspNetUsers", "Id");
        }
    }
}
