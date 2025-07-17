using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThePetRetreat.Models;
using ThePetRetreat.ViewModels;

namespace ThePetRetreat.Controllers
{

    public class ContactSubmissionController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: ContactUs

        [HttpGet]
        public ActionResult Index()
        {
            return View(new ContactSubmissionsVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactSubmissionsVM ContactVm)
        { 

            if (!ModelState.IsValid)
            {
                return View(ContactVm);
            }

            var contact = new ContactSubmissionsModel
            {
                Email = ContactVm.Email,
                Subject = ContactVm.Subject,
                Message = ContactVm.Message
            };

            db.ContactSubmissions.Add(contact);
            db.SaveChanges();

            return RedirectToAction("ContactSubmissionSuccessful");
        }

        public ActionResult ContactSubmissionSuccessful()
        {
            return View();
        }
    }
}