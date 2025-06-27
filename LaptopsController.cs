using LaptopInventoryAPI.Data;
using LaptopInventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaptopsController : Controller
    {
        private readonly AppDbContext _context;

        public LaptopsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/laptops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Laptop>>> GetLaptops()
        {
            return await _context.Laptops.ToListAsync();
        }

        // GET: api/laptops/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Laptop>> GetLaptop(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }

            return laptop;
        }

        // POST: api/laptops
        [HttpPost]
        public async Task<ActionResult<Laptop>> PostLaptop(Laptop laptop)
        {
            _context.Laptops.Add(laptop);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLaptop), new { id = laptop.Id }, laptop);
        }

        // PUT: api/laptops/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaptop(int id, Laptop updatedLaptop)
        {
            if (id != updatedLaptop.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedLaptop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Laptops.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/laptops/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaptop(int id)
        {
            var laptop = await _context.Laptops.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }

            _context.Laptops.Remove(laptop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // NEW WEB PAGE VIEW (NOT API)
        // GET: /Laptops
        [HttpGet("/Laptops")]
        public async Task<IActionResult> IndexView()
        {
            var laptops = await _context.Laptops.ToListAsync();
            ViewBag.Laptops = laptops;
            return View("Index", new Laptop());
        }
    }
}
