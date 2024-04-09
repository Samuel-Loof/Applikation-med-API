using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applikation_med_API.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        // This correctly establishes the relationship between ShoppingCart and CartItem
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        [Range(1, 100, ErrorMessage = "Please select a number between 1 and 100")]
        public int count { get; set; }

        // Foreign key to Account
        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
