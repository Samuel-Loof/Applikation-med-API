using Microsoft.AspNetCore.Mvc.RazorPages;
using Applikation_med_API.Data;
using System.Collections.Generic;
using Applikation_med_API.Models;
using Microsoft.EntityFrameworkCore;

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

    public void OnGet()
    {
        int shoppingCartId = _accessControl.GetCurrentShoppingCartId();
        // Retrieve cart items for the logged-in user's shopping cart
        OrderItems = _database.CartItems
                              .Include(ci => ci.Product) // Assuming you need product details
                              .Where(ci => ci.ShoppingCartId == shoppingCartId)
                              .ToList();

        TotalPrice = OrderItems.Sum(item => item.Price * item.Quantity);
    }
}
