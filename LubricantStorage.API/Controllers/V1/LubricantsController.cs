using LubricantStorage.Core;
using Microsoft.AspNetCore.Mvc;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/lubricants")]
    public class LubricantsController : ControllerBase
    {
        private readonly IRepository<Lubricant> _lubricantRepository;

        public LubricantsController(IRepository<Lubricant> lubricantRepository)
        {
            _lubricantRepository = lubricantRepository;
        }

        [HttpGet("{id}")]
        public async Task<Lubricant> GetById([FromRoute] string id)
        {
            return await _lubricantRepository.Get(l => l.Id == id);
        }

        [HttpPost]
        public async Task Create([FromBody] Lubricant lubricant)
        {
            await _lubricantRepository.Add(lubricant);
        }
    }
}