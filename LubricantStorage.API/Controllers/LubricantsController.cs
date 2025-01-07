using MediatR;
using Microsoft.AspNetCore.Mvc;
using LubricantStorage.API.Models;
using LubricantStorage.API.Application.Lubricants.Commands;
using LubricantStorage.API.Application.Lubricants.Queris;

namespace LubricantStorage.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class LubricantsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<Lubricant> Get([FromRoute] string id)
    {
        var getByIdQuery = new GetLubricantByIdQuery
        {
            Id = id
        };
        return await mediator.Send(getByIdQuery);
    }

    [HttpGet]
    public async Task<IEnumerable<Lubricant>> GetAll()
    {
        var lubricants = await mediator.Send(new GetAllLubricantQuery());

        return lubricants;
    }

    [HttpPost]
    public async Task Create([FromBody] CreateLubricantCommand createLubricantCommand)
    {
        await mediator.Send(createLubricantCommand);
    }
}