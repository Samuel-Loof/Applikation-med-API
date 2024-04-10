using Applikation_med_API.Data;
using Applikation_med_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Applikation_med_API.Controllers
{
    [Route("/api")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly AppDbContext database;

        public APIController(AppDbContext database)
        {
            this.database = database;
        }

        // GET method for products with optional filters for name, category, and pagination support
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts([FromQuery] string name, [FromQuery] string category, [FromQuery] int page = 1)
        {
            const int PageSize = 10;

            // Query of all products
            IQueryable<Product> query = database.Products;

            // If a name filter is provided, apply a LIKE query to filter products by name
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{name}%"));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            // Constructing the base URL from the request to create absolute image URLs
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";


            // Transform the products in the query into a list
            var products = await query
                .Select(p => new
                {
                    p.Name,
                    ImageUrl = baseUrl + "/images/" + p.ImagePath,
                    p.Price,
                    p.Category,
                    p.Description
                })
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            if (!products.Any())
            {
                return NotFound(new { Message = "Inga produkter hittades baserat på den angivna filtreringen." });
            }

            return Ok(products);
        }
    }
}
