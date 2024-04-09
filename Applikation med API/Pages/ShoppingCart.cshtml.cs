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

        public List<Product> CartItems { get; set; }

        public CartModel(AppDbContext database, AccessControl accessControl)
        {
            _database = database;
            _accessControl = accessControl;
        }

        public void OnGet()
        {
            // Retrieve cart items for the logged-in user
            CartItems = _database.Products.Where(p => p.AccountID == _accessControl.LoggedInAccountID).ToList();
        }

        public IActionResult OnPostRemoveItem(int productId)
        {
            var productToRemove = _database.Products.FirstOrDefault(p => p.ID == productId && p.AccountID == _accessControl.LoggedInAccountID);

            if (productToRemove != null)
            {
                // Logic to remove the product from the cart
                _database.Products.Remove(productToRemove);
                _database.SaveChanges();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostClearCart()
        {
            var productsToRemove = _database.Products.Where(p => p.AccountID == _accessControl.LoggedInAccountID).ToList();

            foreach (var product in productsToRemove)
            {
                _database.Products.Remove(product);
            }
            _database.SaveChanges();

            return RedirectToPage();
        }
    }
}
