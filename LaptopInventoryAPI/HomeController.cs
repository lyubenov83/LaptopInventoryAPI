using Microsoft.AspNetCore.Mvc;
using LaptopInventoryAPI.Models;
using LaptopInventoryAPI.Data;
using System.Linq;

namespace LaptopInventoryAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // Display form + laptop list
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Laptops = _context.Laptops.ToList();
            return View();
        }

        // Handle form submission
        [HttpPost]
        public IActionResult Index(Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                // ✅ Calculate Total Price based on UnitPrice and Quantity
                laptop.TotalPrice = laptop.UnitPrice * laptop.Quantity;

                _context.Laptops.Add(laptop);
                _context.SaveChanges();

                ViewBag.Message = "Laptop added successfully!";
                ModelState.Clear();
            }

            ViewBag.Laptops = _context.Laptops.ToList(); // Refresh list
            return View(new Laptop());
        }

        // ✅ Delete selected laptops
        [HttpPost]
        public IActionResult DeleteSelected(int[] selectedIds)
        {
            var laptopsToDelete = _context.Laptops.Where(l => selectedIds.Contains(l.Id)).ToList();

            if (laptopsToDelete.Any())
            {
                _context.Laptops.RemoveRange(laptopsToDelete);
                _context.SaveChanges();

                // ✅ Add a red alert message
                TempData["DeleteMessage"] = "Laptop removed successfully!";
            }

            return RedirectToAction("Index");
        }
    }
}
