using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThePetRetreat.Models
{
    [Table("Schedules")]
    public class SchedulesModel
    {
        [Key]
        public Guid ScheduleID { get; set; }

        public SchedulesModel()
        {
            ScheduleID = Guid.NewGuid();
        }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        [Required]
        public Boolean IsAvailable { get; set; } = true;

        public List<BookingSchedulesModel> BookingSchedules { get; set; } = new List<BookingSchedulesModel>();
    }
}