using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThePetRetreat.Models
{
    [Table("Bookings")]
    public class BookingModel
    {
        [Key]
        public Guid BookingID { get; set; }

        public BookingModel()
        {
            BookingID = Guid.NewGuid();
            DateTimeCreated = DateTime.UtcNow;
            BookingStatus = "Pending";
        }

        [Required]
        [ForeignKey("BookingCreatedByUser")]
        [InverseProperty("BookingsCreated")]
        public string BookingCreatedByUserID { get; set; }
        public ApplicationUser BookingCreatedByUser { get; set; }

        [ForeignKey("CheckedInByUser")]
        [InverseProperty("BookingsCheckedIn")]
        public string CheckedInByUserID { get; set; }
        public ApplicationUser CheckedInByUser { get; set; }

        [ForeignKey("CheckedOutByUser")]
        [InverseProperty("BookingsCheckedOut")]
        public string CheckedOutByUserID { get; set; }
        public ApplicationUser CheckedOutByUser { get; set; }

        [Required]
        public DateTime DateTimeCreated { get; set; } 

        [Required]
        [MaxLength(50)]
        public string BookingStatus { get; set; }

        public DateTime? DateTimeCheckedIn { get; set; }

        public DateTime? DateTimeCheckedOut { get; set; }

        public List<PaymentModel> Payments { get; set; } = new List<PaymentModel>();
        
        public List<BookingPetsModel> BookingPets { get; set; } = new List<BookingPetsModel>();

        public List<BookingSchedulesModel> BookingSchedules { get; set; } = new List<BookingSchedulesModel>();
    }
}