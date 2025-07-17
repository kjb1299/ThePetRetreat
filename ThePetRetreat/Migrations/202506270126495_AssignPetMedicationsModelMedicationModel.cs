namespace ThePetRetreat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignPetMedicationsModelMedicationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        MedicationID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Frequency = c.String(nullable: false, maxLength: 100),
                        Dosage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MedicationID);
            
            CreateTable(
                "dbo.PetMedications",
                c => new
                    {
                        PetMedicationID = c.Guid(nullable: false),
                        PetID = c.Guid(nullable: false),
                        MedicationID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PetMedicationID)
                .ForeignKey("dbo.Medications", t => t.MedicationID, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.PetID, cascadeDelete: true)
                .Index(t => t.PetID)
                .Index(t => t.MedicationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetMedications", "PetID", "dbo.Pets");
            DropForeignKey("dbo.PetMedications", "MedicationID", "dbo.Medications");
            DropIndex("dbo.PetMedications", new[] { "MedicationID" });
            DropIndex("dbo.PetMedications", new[] { "PetID" });
            DropTable("dbo.PetMedications");
            DropTable("dbo.Medications");
        }
    }
}
