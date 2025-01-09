//using Microsoft.AspNetCore.Mvc;
//using LubricantStorage.Core;

//namespace LubricantStorage.API.Controllers.V2
//{
//    [ApiController]
//    [Route("api/v{version:apiVersion}/lubricants")]
//    public class LubricantsController(IMediator mediator) : ControllerBase
//    {
//        [HttpGet("{id}")]
//        public async Task<Lubricant> Get([FromRoute] string id)
//        {
//            var getByIdQuery = new GetLubricantByIdQuery
//            {
//                Id = id
//            };
//            var lubricant = await mediator.Send(getByIdQuery);

//            lubricant.Name = $"v2: {lubricant?.Name}";

//            return lubricant;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<Lubricant>> GetAll()
//        {
//            return await mediator.Send(new GetAllLubricantQuery());
//        }

//        [HttpPost]
//        public async Task Create([FromBody] CreateLubricantCommand createLubricantCommand)
//        {
//            await mediator.Send(createLubricantCommand);
//        }
//    }
//}