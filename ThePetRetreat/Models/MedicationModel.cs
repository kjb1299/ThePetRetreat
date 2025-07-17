using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThePetRetreat.Models
{
    [Table("Medications")]
    public class MedicationModel
    {
        [Key]
        public Guid MedicationID { get; set; }

        public MedicationModel()
        {
            MedicationID = Guid.NewGuid();
        }

        [Required]  
        [MaxLength(100)]

        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Frequency { get; set; }

        [Required]
        public decimal Dosage { get; set; }

        public List<PetMedicationsModel> PetMedications { get; set; } = new List<PetMedicationsModel>();
    }
}