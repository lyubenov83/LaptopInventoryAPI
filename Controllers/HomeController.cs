using Microsoft.AspNetCore.Mvc;
using LaptopInventoryAPI.Data;
using LaptopInventoryAPI.Models;

namespace LaptopInventoryAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Inject ApplicationDbContext via constructor
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show empty form
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Process form submission
        [HttpPost]
        public IActionResult Index(Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                _context.Laptops.Add(laptop);     // Add the new laptop entity
                _context.SaveChanges();            // Save changes to the database

                ViewBag.Message = "Laptop added successfully!";
                ModelState.Clear();                // Clear form after successful submission
                return View();
            }
            else
            {
                // If validation fails, return the form with validation messages
                return View(laptop);
            }
        }
    }
}
