using System.ComponentModel.DataAnnotations;

namespace Applikation_med_API.Models
{
    public class Product
    {
        //public Account Account { get; set; }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; } 
        public double Price { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
    }
}
