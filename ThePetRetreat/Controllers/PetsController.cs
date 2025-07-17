using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThePetRetreat.Models;

namespace ThePetRetreat.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPet(string name, string breed, string species, int age, string specialInstructions,
            string feedingFrequency, decimal feedingAmount, string feedingUnit)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            PetModel newPet = new PetModel
            {
                Name = name,
                Breed = breed,
                Species = species,
                Age = age,
                SpecialInstructions = specialInstructions,
                FeedingFrequency = feedingFrequency,
                FeedingAmount = feedingAmount,
                FeedingUnit = feedingUnit
            };

            dbContext.Pets.Add(newPet);

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error creating pet: " + ex.Message);
            }

            return Content("Pet Created");
        }

        public ActionResult RemovePet (Guid id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            PetModel petToRemove = dbContext.Pets.FirstOrDefault(p => p.PetID == id);
            if (petToRemove == null)
            {
                return Content("Pet not found");
            }

            dbContext.Pets.Remove(petToRemove);

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return Content("Error removing pet: " + ex.Message);
            }
            return Content("Pet Removed");
        }
    }
}