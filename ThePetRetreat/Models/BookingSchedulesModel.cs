using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ThePetRetreat.Migrations;

namespace ThePetRetreat.Models
{
    [Table("BookingSchedules")]
    public class BookingSchedulesModel
    {
        [Key]
        public Guid BookingScheduleID { get; set; }

        public BookingSchedulesModel()
        {
            BookingScheduleID = Guid.NewGuid();
        }

        [Required]
        [ForeignKey("Booking")]
        public Guid BookingID { get; set; }
        public BookingModel Booking { get; set; }

        [Required]
        [ForeignKey("Schedule")]
        public Guid ScheduleID { get; set; }
        public SchedulesModel Schedule { get; set; }
    }
}