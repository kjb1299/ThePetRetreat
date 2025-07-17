using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThePetRetreat.Models
{
    [Table("UsersToPets")]
    public class UsersToPetsModel
    {
        [Key]
        public Guid UsersToPetsID { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey("Pet")]
        public Guid PetID { get; set; }
        public PetModel Pet { get; set; }

        [Required]
        public string RelationshipType { get; set; }

        public UsersToPetsModel()
        {
            UsersToPetsID = Guid.NewGuid();
        }
    }
}