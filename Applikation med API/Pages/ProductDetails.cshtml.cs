using Applikation_med_API.Data;
using Applikation_med_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Applikation_med_API.Pages
{
    public class ProductDetailsModel : PageModel
    {

        private readonly AppDbContext _database;
        public Product Product { get; set; }

        public ProductDetailsModel(AppDbContext database)
        {
            _database = database;
        }

        public async Task<IActionResult> OnGetAsync(int iD)
        {
            Product = await _database.Products.FirstOrDefaultAsync(p => p.ID == iD);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
