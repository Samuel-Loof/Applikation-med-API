using Applikation_med_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Applikation_med_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Applikation_med_API.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _database;

        public IndexModel(AppDbContext database)
        {
            _database = database;
        }

        // Property to hold products
        public IList<Product> Products { get; set; }

        // Asynchronous method to load products from the database
        public async Task OnGetAsync()
        {
            Products = await _database.Products.AsNoTracking().ToListAsync();
        }

       
    }
}