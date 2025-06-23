using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using LaptopInventoryAPI.Data; // Make sure this matches your actual namespace

namespace LaptopInventoryAPI.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // MySQL connection string with your password
            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=laptopdb;user=root;password=Summerof2025",
                new MySqlServerVersion(new Version(8, 0, 36))
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
    