using Applikation_med_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Applikation_med_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Applikation_med_API.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _database;
        private readonly AccessControl _accessControl;
        public List<Product> Products;
        public List<Product> Cart;

        public IndexModel(AppDbContext database, AccessControl accessControl)
        {
            _database = database;
            _accessControl = accessControl;
        }

        public void OnGet()
        {
            // Find all products.
            Products = _database.Products.OrderBy(p => p.Name).ToList();

            // Find the products assigned to the logged-in user.
            Cart = _database
                .Products
                .Where(p => p.AccountID == _accessControl.LoggedInAccountID)
                .ToList();
        }

        public IActionResult OnPost(int productId)
        {
            var product = _database.Products.Find(productId); // Find the submitted product.
            product.AccountID = _accessControl.LoggedInAccountID; // Assign the product to the logged-in user.

            _database.SaveChanges();

            // Redirect to the GET method, so we don't have to load the list of products in OnPost.
            return RedirectToPage();
        }
    }
}
