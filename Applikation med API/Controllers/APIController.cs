using Applikation_med_API.Data;
using Applikation_med_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace Applikation_med_API.Controllers
{

    [ApiController]
    [Route("/api/products")]
    public class ProductsApiController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ProductsApiController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] string? name = null, [FromQuery] string? category = null, [FromQuery] int page = 1)
        // Name and category are set to null to make these fields not required when searching for a product
        {
            const int PageSize = 10;
            IQueryable<Product> query = _dbContext.Products;

            // Apply name filter if provided
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{name}%"));
            }

            // Apply category filter if provided
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            var totalItems = await query.CountAsync();
            var products = await query
                .OrderBy(p => p.Name)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(p => new
                {
                    p.Name,
                    ImageUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/ProductDetails?id={p.ID}",
                    p.Price,
                    p.Category,
                    p.Description
                })
                .ToListAsync();

            if (products.Count == 0)
            {
                return NotFound(new { Message = "No products found based on the provided filters." });
            }

            return Ok(new
            {
                TotalCount = totalItems,
                Products = products
            });
        }
    }
}

