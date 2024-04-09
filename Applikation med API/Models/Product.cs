using System.ComponentModel.DataAnnotations;

namespace Applikation_med_API.Models
{
    public class Product
    {
        public Account? Account { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }

        public string? ImagePath { get; set; }

        public int? AccountID { get; set; } // connect the product to an account

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string? ImagePath { get; set; }
 
        public string? Category { get; set; }

        public int? AccountID { get; set; } // connect the product to an account

        public string? Description { get; set; }
    }
}
