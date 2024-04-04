using System.ComponentModel.DataAnnotations;

namespace Applikation_med_API.Models
{
    public class Product
    {

        public string Name { get; set; }

        //[Required]
        //public string ImageFileName { get; set; } // Namn på bildfilen i undermapp till wwwroot

        public decimal Price { get; set; }


        public string Category { get; set; }

        public string? Description { get; set; }
    }
}
