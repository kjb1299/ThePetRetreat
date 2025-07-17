using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThePetRetreat.Models
{
    [Table("Payments")]
    public class PaymentModel
    {
        [Key]
        public Guid PaymentID { get; set; }

        [Required]
        [ForeignKey("Booking")]
        public Guid BookingID { get; set; }
        public BookingModel Booking { get; set; }

        public PaymentModel()
        {
            PaymentID = Guid.NewGuid();
        }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(50)]
        public string Method { get; set; }
    }
}