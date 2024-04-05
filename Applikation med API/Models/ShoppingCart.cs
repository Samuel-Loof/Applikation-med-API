using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Applikation_med_API.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; } // Link to Account

        //public virtual List<CartItem> Items { get; set; } = new List<CartItem>();


        // Initializes CartItems as a new List<CartItem> to prevent null references
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }

}
