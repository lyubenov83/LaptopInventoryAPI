using Microsoft.EntityFrameworkCore;
using LaptopInventoryAPI.Models;
using System.Collections.Generic;

namespace LaptopInventoryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Laptop> Laptops { get; set; }
    }
}
