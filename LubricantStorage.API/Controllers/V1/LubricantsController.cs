using LubricantStorage.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var lubricant = await _lubricantRepository.Get(l => l.Id == id);
                return Ok(lubricant);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lubricants = await _lubricantRepository.List(l => true);
                return Ok(lubricants);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Lubricant lubricant)
        {
            try
            {
                await _lubricantRepository.Add(lubricant);
                return Created();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] Lubricant lubricant)
        {
            try
            {
                await _lubricantRepository.Update(lubricant);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Remove(string id)
        {
            try
            {
                await _lubricantRepository.Remove(l => l.Id == id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("check-any/{value}")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckAny(string value)
        {
            try
            {
                var result = await _lubricantRepository.CheckAny(l => l.Name == value);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            } 
        }

        [HttpGet("check-all/{value}")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckAll(string value)
        {
            try
            {
                var result = await _lubricantRepository.CheckAll(l => l.Name == value);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}