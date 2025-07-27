using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NN.NandiniSarees.Models;
using NN.NandiniSarees.Repositories;

namespace NN.NandiniSareesWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SareesController : ControllerBase
    {
        private readonly ISareesRepository _repository;

        public SareesController(ISareesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Sarees>> Get()
        {
            return await _repository.GetAllAsync();
        }
    }
}
