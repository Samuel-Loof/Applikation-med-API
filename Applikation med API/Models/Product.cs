using System.ComponentModel.DataAnnotations;

namespace Applikation_med_API.Models
{
    public class Product
    {
        public Account Account { get; set; }
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }

        public int AccountID { get; set; } // Might need this to connect the product to an account

        //[Required]
        //public string ImageFileName { get; set; } // Namn på bildfilen i undermapp till wwwroot

        public int Price { get; set; }


        public string? Category { get; set; }

        public string? Description { get; set; }
    }
}
