using Microsoft.AspNetCore.Mvc;

namespace Cf.Laundry.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("index")]
        public object Get()
        {
            return new { code = "success" };
        }
    }
}
