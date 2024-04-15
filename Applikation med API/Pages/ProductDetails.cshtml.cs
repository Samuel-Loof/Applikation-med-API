using Applikation_med_API.Data;
using Applikation_med_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Applikation_med_API.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly AppDbContext _database;
        private readonly AccessControl _accessControl;


        public Product Product { get; set; }

        public ProductDetailsModel(AppDbContext database, AccessControl accessControl)
        {
            _database = database;
            _accessControl = accessControl;

        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _database.Products.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int productId)
        {
            int shoppingCartId = _accessControl.GetCurrentShoppingCartId();

            var existingCartItem = await _database.CartItems
                .SingleOrDefaultAsync(ci => ci.ProductId == productId && ci.ShoppingCartId == shoppingCartId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                var product = await _database.Products.FindAsync(productId);
                if (product != null)
                {
                    var newCartItem = new CartItem
                    {
                        ImagePath = product.ImagePath,
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

            return RedirectToPage("/Index");
        }
    }
}
