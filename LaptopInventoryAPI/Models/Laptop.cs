using System.ComponentModel.DataAnnotations;

namespace LaptopInventoryAPI.Models
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        public decimal Price { get; set; }

        public bool InStock { get; set; }
    }
}
