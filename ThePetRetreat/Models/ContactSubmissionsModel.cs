using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThePetRetreat.Models
{
    [Table("ContactSubmissions")]
    public class ContactSubmissionsModel
    {
        [Key]
        public Guid ContactSubmissionsID { get; set; }

        public ContactSubmissionsModel()
        {
            ContactSubmissionsID = Guid.NewGuid();
            IsResolved = false;
            SubmissionDate = DateTime.UtcNow;
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public Boolean IsResolved { get; set; }
    }
}