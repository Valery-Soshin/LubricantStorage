using Microsoft.AspNetCore.Mvc;

namespace OilStorage.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OilsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Oil 1";
        }
    }

    class Oil
    {

    }

    class OilGrade
    {

    }

    class Storage
    {

    }
}