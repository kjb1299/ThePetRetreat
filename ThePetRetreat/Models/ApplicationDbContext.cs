using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ThePetRetreat.Models
{
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PetModel> Pets { get; set; }
        public DbSet<UsersToPetsModel> UsersToPets { get; set; }
        public DbSet<MedicationModel> Medications { get; set; }
        public DbSet<PetMedicationsModel> PetMedications { get; set; }
        public DbSet<BookingPetsModel> PetTypes { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }

        public DbSet<BookingSchedulesModel> BookingSchedules { get; set; }
        public DbSet<SchedulesModel> Schedules { get; set; }

        public DbSet<ContactSubmissionsModel> ContactSubmissions { get; set; }
        public DbSet<EmergencyContactModel> EmergencyContacts { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}