﻿using Microsoft.EntityFrameworkCore;
using LaptopInventoryAPI.Models;

namespace LaptopInventoryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Laptop> Laptops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Laptop>()
                .Property(l => l.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Laptop>()
                .Property(l => l.TotalPrice)
                .HasPrecision(18, 2);
        }
    }
}
