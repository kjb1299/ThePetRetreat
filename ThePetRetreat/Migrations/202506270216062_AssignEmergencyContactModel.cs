namespace ThePetRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignEmergencyContactModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmergencyContacts",
                c => new
                    {
                        EmergencyContactID = c.Guid(nullable: false),
                        PetID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false),
                        Relationship = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EmergencyContactID)
                .ForeignKey("dbo.Pets", t => t.PetID, cascadeDelete: true)
                .Index(t => t.PetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmergencyContacts", "PetID", "dbo.Pets");
            DropIndex("dbo.EmergencyContacts", new[] { "PetID" });
            DropTable("dbo.EmergencyContacts");
        }
    }
}
