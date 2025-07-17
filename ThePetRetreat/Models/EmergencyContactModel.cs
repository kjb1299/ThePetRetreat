using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThePetRetreat.Models
{
    [Table("EmergencyContacts")]
    public class EmergencyContactModel
    {
        [Key]
        public Guid EmergencyContactID { get; set; }

        [Required]
        [ForeignKey("Pet")]
        public Guid PetID { get; set; }
        public PetModel Pet { get; set; }

        public EmergencyContactModel() 
        { 
            EmergencyContactID = Guid.NewGuid();
        }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }    

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Relationship { get; set; }
    }
}