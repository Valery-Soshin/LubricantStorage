using MediatR;
using Microsoft.AspNetCore.Mvc;
using LubricantStorage.API.Commands;
using LubricantStorage.API.Queris;
using LubricantStorage.Core;

namespace LubricantStorage.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LubricantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LubricantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<Lubricant> GetAsync(string id)
        {
            var getByIdQuery = new GetLubricantByIdQuery
            {
                Id = id
            };
            return await _mediator.Send(getByIdQuery);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllLubricantQuery());

            return null;
        }

        [HttpPost]
        public async Task Create([FromBody]CreateLubricantCommand createLubricantCommand)
        {
            await _mediator.Send(createLubricantCommand);
        }
    }
}