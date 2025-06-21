using System.ComponentModel.DataAnnotations;

namespace LaptopInventoryAPI.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Model { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        public bool InStock { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
