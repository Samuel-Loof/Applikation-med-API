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
        public List<CartItem> CartItems;
        public List<Product> Cart;

        public IndexModel(AppDbContext database, AccessControl accessControl)
        {
            _database = database;
            _accessControl = accessControl;
        }

        public async Task OnGetAsync()
        {
            Products = await _database.Products.OrderBy(p => p.Name).ToListAsync();

            int shoppingCartId = _accessControl.GetCurrentShoppingCartId();
            CartItems = await _database.CartItems
                                       .Where(c => c.ShoppingCartId == shoppingCartId)
                                       .Include(c => c.Product)
                                       .ToListAsync();
        }


        public async Task<IActionResult> OnPostAsync(int productId)
        {
            // Assuming _accessControl has a way to get the current ShoppingCartId
            int shoppingCartId = _accessControl.GetCurrentShoppingCartId();

            var existingCartItem = await _database.CartItems
                                                  .FirstOrDefaultAsync(ci => ci.ProductId == productId && ci.ShoppingCartId == shoppingCartId);

            if (existingCartItem != null)
            {
                // Product already in cart, increment quantity
                existingCartItem.Quantity += 1;
            }
            else
            {
                // Product not in cart, add new CartItem
                var product = await _database.Products.FindAsync(productId);
                if (product != null)
                {
                    var newCartItem = new CartItem
                    {
                        ProductId = productId,
                        ShoppingCartId = shoppingCartId,
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = 1
                    };
                    _database.CartItems.Add(newCartItem);
                }
            }

            await _database.SaveChangesAsync();
            return RedirectToPage();
        }

    }
}
