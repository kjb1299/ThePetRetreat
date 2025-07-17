using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThePetRetreat.Models
{
    [Table("BookingPets")]
    public class BookingPetsModel
    {
        [Key]
        public Guid BookingPetID { get; set; }

        public BookingPetsModel()
        {
            BookingPetID = Guid.NewGuid();
        }

        [Required]
        [ForeignKey("Booking")]
        public Guid BookingID { get; set; }
        public BookingModel Booking { get; set; }

        [Required]
        [ForeignKey("Pet")]
        public Guid PetID { get; set; }
        public PetModel Pet { get; set; }
    }
}