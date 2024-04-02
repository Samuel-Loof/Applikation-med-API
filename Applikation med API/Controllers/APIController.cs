using Applikation_med_API.Data;
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
    }
}
