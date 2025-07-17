using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThePetRetreat.Models;

namespace ThePetRetreat.Controllers
{
    public class BookingsController : Controller
    {
        // GET: Bookings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBooking(string userId, List<Guid> petIds, DateTime? checkedIn, DateTime? checkedOut)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            // Validate userId
            if (string.IsNullOrEmpty(userId))
            {
                return Content("User ID cannot be null or empty.");
            }

            // Validate petId(s)
            if (petIds == null || petIds.Count == 0)
            {
                return Content("At least one pet ID must be provided.");
            }

            // Validate checkin and checkout values
            if (checkedIn.HasValue && checkedOut.HasValue && checkedIn >= checkedOut)
            {
                return Content("Check-in date must be before check-out date.");
            }

            BookingModel newBooking = new BookingModel
            {
                BookingCreatedByUserID = userId,
                DateTimeCheckedIn = checkedIn,
                DateTimeCheckedOut = checkedOut
            };

            // Add pets and booking to BookingPetsModel
            foreach (var petId in petIds)
            {
                newBooking.BookingPets.Add(new BookingPetsModel
                {
                    BookingID = newBooking.BookingID,
                    PetID = petId
                });
            }

            dbContext.Bookings.Add(newBooking);

            try
            {
                dbContext.SaveChanges();
                return Content("Booking created succesfully");
            }
            catch (Exception ex)
            {
                return Content("Error creating booking: " + ex.Message);
            }
        }

        public ActionResult RemoveBooking(Guid bookingId)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            BookingModel bookingToRemove = dbContext.Bookings
                .Include("BookingPets")
                .FirstOrDefault(b => b.BookingID == bookingId);
            if (bookingToRemove == null)
            {
                return Content("Booking not found");
            }
            dbContext.Bookings.Remove(bookingToRemove);
            try
            {
                dbContext.SaveChanges();
                return Content("Booking removed successfully");
            }
            catch (Exception ex)
            {
                return Content("Error removing booking: " + ex.Message);
            }
        }
    }
}