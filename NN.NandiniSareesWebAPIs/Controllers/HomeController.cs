using Microsoft.AspNetCore.Mvc;
using NN.NandiniSarees.Models;

namespace NN.NandiniSareesWebAPIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSarees")]
        public IEnumerable<Sarees> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Sarees
            {
                Id = index,
                Name = $"Saree {index}",
                Description = $"Description for Saree {index}",
                ImageUrl = $"https://images.unsplash.com/photo-1519125323398-675f0ddb6308?auto=format&fit=crop&w=800&q=80",
                Price = 999.99m * index,
                Category = index % 2 == 0 ? "Silk" : "Cotton",
                CreatedAt = DateTime.UtcNow.AddDays(-index),
                UpdatedAt = DateTime.UtcNow
            })
            .ToArray();
        }
    }
}
