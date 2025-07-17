namespace ThePetRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignContactSubmissionsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactSubmissions",
                c => new
                    {
                        ContactSubmissionsID = c.Guid(nullable: false),
                        UserID = c.String(maxLength: 128),
                        Subject = c.String(nullable: false, maxLength: 50),
                        Message = c.String(nullable: false, maxLength: 1000),
                        SubmissionDate = c.DateTime(nullable: false),
                        IsResolved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactSubmissionsID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactSubmissions", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.ContactSubmissions", new[] { "UserID" });
            DropTable("dbo.ContactSubmissions");
        }
    }
}
