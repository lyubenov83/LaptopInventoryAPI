using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using LaptopInventoryAPI.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace LaptopInventoryAPI.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;user=root;password=Summerof2025;database=laptopdb",
                new MySqlServerVersion(new Version(8, 0, 36))
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
