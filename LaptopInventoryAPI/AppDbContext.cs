using LaptopInventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopInventoryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Laptop> Laptops { get; set; }
    }
}
