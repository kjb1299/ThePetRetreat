namespace ThePetRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContactSubmisisonsModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactSubmissions", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.ContactSubmissions", new[] { "UserID" });
            AddColumn("dbo.ContactSubmissions", "Email", c => c.String(nullable: false));
            DropColumn("dbo.ContactSubmissions", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactSubmissions", "UserID", c => c.String(maxLength: 128));
            DropColumn("dbo.ContactSubmissions", "Email");
            CreateIndex("dbo.ContactSubmissions", "UserID");
            AddForeignKey("dbo.ContactSubmissions", "UserID", "dbo.AspNetUsers", "Id");
        }
    }
}
