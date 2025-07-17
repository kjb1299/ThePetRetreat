namespace ThePetRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignSchedulesModelBookingSchedulesModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingSchedules",
                c => new
                    {
                        BookingScheduleID = c.Guid(nullable: false),
                        BookingID = c.Guid(nullable: false),
                        ScheduleID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BookingScheduleID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleID, cascadeDelete: true)
                .Index(t => t.BookingID)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Guid(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        IsAvailabe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingSchedules", "ScheduleID", "dbo.Schedules");
            DropForeignKey("dbo.BookingSchedules", "BookingID", "dbo.Bookings");
            DropIndex("dbo.BookingSchedules", new[] { "ScheduleID" });
            DropIndex("dbo.BookingSchedules", new[] { "BookingID" });
            DropTable("dbo.Schedules");
            DropTable("dbo.BookingSchedules");
        }
    }
}
