namespace ThePetRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSchedulesModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "IsAvailable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Schedules", "IsAvailabe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "IsAvailabe", c => c.Boolean(nullable: false));
            DropColumn("dbo.Schedules", "IsAvailable");
        }
    }
}
