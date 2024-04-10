using Applikation_med_API.Data;
using Applikation_med_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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




        [HttpGet("products")]
        public async Task<IActionResult> GetProducts([FromQuery] string name, [FromQuery] string category, [FromQuery] int page = 1)
        {
            const int PageSize = 10;

            IQueryable<Product> query = this.database.Products;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{name}%"));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            var products = await query
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound(new { Message = "Inga produkter hittades baserat på den angivna filtreringen." });
            }

            return Ok(products);
        }
    }
}
