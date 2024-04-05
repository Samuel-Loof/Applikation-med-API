using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic; 
using Applikation_med_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Applikation_med_API.Data;
using System.Security.Claims;
using Applikation_med_API.Extensions;

namespace Applikation_med_API.Pages
{
    public class CartModel : PageModel
    {
        private readonly AppDbContext _context;

        private int GetUserAccountId()
        {
            string currentUserOpenIDIssuer = "https://example.com"; 
            string currentUserOpenIDSubject = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 

            var account = _context.Accounts.FirstOrDefault(a => a.OpenIDIssuer == currentUserOpenIDIssuer && a.OpenIDSubject == currentUserOpenIDSubject);
            return account?.ID ?? 0;
        }

        public CartModel(AppDbContext context) 
        {
            _context = context;
        }
        public List<CartItem> CartItems { get; set; } // List to display items in the shopping cart

        public void OnGet()
        {
            // Ensure CartItems is always initialized
            CartItems = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
        }

 
        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            int userAccountId = GetUserAccountId();
            if (userAccountId == 0)
            {
                return RedirectToPage();
            }

            var cart = await _context.ShoppingCarts
                                     .Include(c => c.CartItems)
                                     .FirstOrDefaultAsync(c => c.AccountId == userAccountId);

            var product = await _context.Products.FindAsync(productId);
            if (product == null) return Page();

            if (cart == null)
            {
                cart = new ShoppingCart { AccountId = userAccountId };
                _context.ShoppingCarts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var item = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity += 1; // Increment quantity by 1
            }
            else
            {
                // Add new item to the cart with a quantity of 1
                cart.CartItems.Add(new CartItem { ProductId = productId, Name = product.Name, Price = product.Price, Quantity = 1 });
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }



        public IActionResult OnPostRemoveAll()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToPage(); // Refresh the page to show the empty cart
        }

        public IActionResult OnPostRemoveItem(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            cart.RemoveAll(x => x.ProductId == productId);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToPage(); 
        }
    }
}