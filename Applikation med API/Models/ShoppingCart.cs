﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applikation_med_API.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ID { get; set; }

        // This establishes the relationship between ShoppingCart and CartItem
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        // Foreign key to Account
        public int AccountID { get; set; }

        public Account Account { get; set; }
    }
}
