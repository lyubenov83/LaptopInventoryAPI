using System.ComponentModel.DataAnnotations;

namespace LaptopInventoryAPI.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        // ✅ Writable so controller can set it
        public decimal TotalPrice { get; set; }

        public bool InStock { get; set; } = true;
    }
}
