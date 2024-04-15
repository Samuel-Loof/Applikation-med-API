using Microsoft.AspNetCore.Mvc.RazorPages;
using Applikation_med_API.Data;
using System.Collections.Generic;
using Applikation_med_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

public class OrderConfirmationModel : PageModel
{
    private readonly AppDbContext _database;
    private readonly AccessControl _accessControl;

    public List<CartItem> OrderItems { get; set; } = new List<CartItem>();
    public decimal TotalPrice { get; set; }

    public OrderConfirmationModel(AppDbContext database, AccessControl accessControl)
    {
        _database = database;
        _accessControl = accessControl;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        int shoppingCartId = _accessControl.GetCurrentShoppingCartId();
        // Retrieve cart items for the logged-in user's shopping cart
        OrderItems = await _database.CartItems
                              .Include(ci => ci.Product) 
                              .Where(ci => ci.ShoppingCartId == shoppingCartId)
                              .ToListAsync();

        if (!OrderItems.Any())
        {
            return RedirectToPage("/Index");
        }

        TotalPrice = OrderItems.Sum(item => item.Price * item.Quantity);

        // Clear the cart after confirming the order
        await ClearCart(shoppingCartId);

        return Page();
    }

    private async Task ClearCart (int shoppingCartId)
    {
        var itemsToRemove = _database.CartItems.Where(ci => ci.ShoppingCartId == shoppingCartId);
        _database.CartItems.RemoveRange(itemsToRemove);
        await _database.SaveChangesAsync();

    }
}
