using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThePetRetreat.Models
{
    [Table("PetMedications")]
    public class PetMedicationsModel
    {
        [Key]
        public Guid PetMedicationID { get; set; }

        public PetMedicationsModel()
        {
            PetMedicationID = Guid.NewGuid();
        }

        [Required]  
        [ForeignKey("Pet")]
        public Guid PetID { get; set; }
        public PetModel Pet { get; set; }

        [Required]
        [ForeignKey("Medication")]
        public Guid MedicationID { get; set; }
        public MedicationModel Medication { get; set; }
    }
}