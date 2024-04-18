using Applikation_med_API.Models;

public class CartItem
{
    public int ID { get; set; }
    public int ProductId { get; set; }
    public int ShoppingCartId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? ImagePath { get; set; }

    // Navigation properties
    public Product Product { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
}

