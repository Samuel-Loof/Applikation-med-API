using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Applikation_med_API.Data;
using Applikation_med_API.Models;

namespace Applikation_med_API.Pages
{
    public class CartModel : PageModel
    {
        private readonly AppDbContext _database;
        private readonly AccessControl _accessControl;

        //public List<Product> CartItems { get; set; } = new List<CartItem>();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public CartModel(AppDbContext database, AccessControl accessControl)
        {
            _database = database;
            _accessControl = accessControl;
        }

        public void OnGet()
        {
            int shoppingCartId = _accessControl.GetCurrentShoppingCartId();
            // Retrieve cart items for the logged-in user's shopping cart
            CartItems = _database.CartItems
                                 .Where(ci => ci.ShoppingCartId == shoppingCartId)
                                 .ToList();
        }

        public IActionResult OnPostRemoveItem(int cartItemId)
        {
            var cartItemToRemove = _database.CartItems.FirstOrDefault(ci => ci.ID == cartItemId && ci.ShoppingCartId == _accessControl.GetCurrentShoppingCartId());

            if (cartItemToRemove != null)
            {
                // Logic to remove the cart item from the cart
                _database.CartItems.Remove(cartItemToRemove);
                _database.SaveChanges();
            }

            // currently when trying to remove a single item, temporary removes it,
            // but when adding another item to the shopping cart it fetches the old items and adds another
            return RedirectToPage();
        }

        public IActionResult OnPostClearCart()
        {
            int shoppingCartId = _accessControl.GetCurrentShoppingCartId(); // Ensure this method exists and correctly fetches the ID
            var cartItemsToRemove = _database.CartItems.Where(ci => ci.ShoppingCartId == shoppingCartId).ToList();

            foreach (var cartItem in cartItemsToRemove)
            {
                _database.CartItems.Remove(cartItem);
            }
            _database.SaveChanges();

            return RedirectToPage();
        }
    }
}