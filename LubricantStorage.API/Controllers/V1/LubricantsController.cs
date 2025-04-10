using LubricantStorage.API.Helpers;
using LubricantStorage.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace LubricantStorage.API.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LubricantsController : ControllerBase
    {
        private readonly ILubricantRepository _lubricantRepository;

        public LubricantsController(ILubricantRepository lubricantRepository)
        {
            _lubricantRepository = lubricantRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string id)
        {
            var lubricant = await _lubricantRepository.Get(l => l.Id == id);
            return Ok(lubricant);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var lubricants = await _lubricantRepository.List(l => true);
            return Ok(lubricants);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] Lubricant lubricant)
        {
            await _lubricantRepository.Add(lubricant);
            return Created();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] Lubricant lubricant)
        {
            await _lubricantRepository.Update(lubricant);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Remove(string id)
        {
            await _lubricantRepository.Remove(l => l.Id == id);
            return Ok();
        }

        [HttpGet("reload")]
        public async Task<IActionResult> Reload()
        {
            await _lubricantRepository.Remove(t => true);

            var testLubricants = LubricantDataHelper.GetTestLubricants();
            foreach (var lubricant in testLubricants)
            {
                await _lubricantRepository.Add(lubricant);
            }

            return Ok();
        }

        [HttpGet("check-any/{value}")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckAny(string value)
        {
            var result = await _lubricantRepository.CheckAny(l => l.Name == value);
            return Ok(result);
        }
    }
}