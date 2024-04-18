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

        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }


        public string CurrentFilter { get; set; }
        public List<string> Categories { get; set; } = new List<string>();


        public IndexModel(AppDbContext database, AccessControl accessControl)
        {
            _database = database;
            _accessControl = accessControl;
        }

        public async Task OnGetAsync(string name, string category, int currentPage = 1)
        {
            ViewData["CurrentFilter"] = name;

            //Fetch and set categories from the database to the dropdown
            // Distinct removes the duplicate elements from a sequence (list) and returns the distinct elements from a single data source
            ViewData["Categories"] = await _database.Products.Select(p => p.Category).Distinct().ToListAsync();

            // Sets up a queryable object that allows further actions like filterning and ordering.
            IQueryable<Product> productQuery = _database.Products;

            //If there's an input, check which product name contain the substring provided
            if (!string.IsNullOrEmpty(name))
            {
                productQuery = productQuery.Where(p => EF.Functions.Like(p.Name, $"%{name}%"));
            }


            //category filter
            if (!string.IsNullOrEmpty(category))
            {
                productQuery = productQuery.Where(p => p.Category == category);
            }


            // Pagination 
            const int PageSize = 10;
            var totalProductsCount = await _database.Products.CountAsync();
            TotalPages = (int)Math.Ceiling(totalProductsCount / (double)PageSize);
            CurrentPage = currentPage;

            Products = await productQuery
                                      .OrderBy(p => p.Name)
                                      .Skip((currentPage - 1) * PageSize)
                                      .Take(PageSize)
                                      .ToListAsync();

            // Fetching cart items
            int shoppingCartId = _accessControl.GetCurrentShoppingCartId();
            var CartItems = await _database.CartItems
                                       .Where(c => c.ShoppingCartId == shoppingCartId)
                                       .Include(c => c.Product)
                                       .ToListAsync();

            ViewData["CartItems"] = CartItems; //Store the cart items in ViewData
        }


        public async Task<IActionResult> OnPostAsync(int productId, int currentPage = 1)
        {
            //get the current ShoppingCartId
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
            return RedirectToPage(new { currentPage } );
        }

    }

}
