using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ThePetRetreat.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public List<UsersToPetsModel> UsersToPets { get; set; } = new List<UsersToPetsModel>();

        [InverseProperty("BookingCreatedByUser")]
        public List<BookingModel> BookingCreated { get; set; } = new List<BookingModel>();

        [InverseProperty("CheckedInByUser")]
        public List<BookingModel> BookingsCheckedIn { get; set; } = new List<BookingModel>();

        [InverseProperty("CheckedOutByUser")]
        public List<BookingModel> BookingsCheckedOut { get; set; } = new List<BookingModel>();

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}