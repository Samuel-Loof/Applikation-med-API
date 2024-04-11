using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Applikation_med_API.Data;
using Applikation_med_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Applikation_med_API.Pages
{
    public class CartModel : PageModel
    {
        private readonly AppDbContext _database;
        private readonly AccessControl _accessControl;

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
                                 .Include(p => p.Product)
                                 .ToList();
        }

        public async Task<IActionResult> OnPostRemoveProduct(int cartItemId)
        {
            var cartItem = await _database.CartItems
                .FirstOrDefaultAsync(ci => ci.ID == cartItemId && ci.ShoppingCartId == _accessControl.GetCurrentShoppingCartId());

            if (cartItem != null)
            {
                // Logic to remove the cart item from the cart
                _database.CartItems.Remove(cartItem);
                await _database.SaveChangesAsync();
            }

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

        public async Task<IActionResult> OnPostIncrementQuantity(int cartItemId)
        {
            var cartItem = await _database.CartItems.FindAsync(cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity += 1;
                await _database.SaveChangesAsync();
            }
            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostDecrementQuantity(int cartItemId)
        {
            var cartItem = await _database.CartItems.FindAsync(cartItemId);
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    // If quantity is greater than 1, decrement it
                    cartItem.Quantity -= 1;
                }
                else
                {
                    // If quantity is 1, remove the item from the cart
                    _database.CartItems.Remove(cartItem);
                }
                await _database.SaveChangesAsync();
            }
            return RedirectToPage();
        }


    }
}