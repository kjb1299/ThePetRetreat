using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThePetRetreat.Models
{
    [Table("Pets")]
    public class PetModel
    {
        [Key]
        public Guid PetID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }    

        [Required]
        [MaxLength(100)]
        public string Breed { get; set; }

        [Required]
        [MaxLength(100)]
        public string Species { get; set; }

        [Required]
        public int Age { get; set; }

        [MaxLength(2000)]
        public string SpecialInstructions { get; set; }

        [Required]
        [MaxLength(100)]    
        public string FeedingFrequency { get; set; }

        [Required]
        public decimal FeedingAmount { get; set; }

        [Required]
        [MaxLength(500)]
        public string FeedingUnit { get; set; }

        public PetModel()
        {
            PetID = Guid.NewGuid();
        }

        public List<UsersToPetsModel> UsersToPets { get; set; } = new List<UsersToPetsModel>();

        public List<PetMedicationsModel> PetMedications { get; set; } = new List<PetMedicationsModel>();

        public List<BookingPetsModel> BookingPets { get; set; } = new List<BookingPetsModel>();

        public List<EmergencyContactModel> EmergencyContacts { get; set; } = new List<EmergencyContactModel>();
    }
}