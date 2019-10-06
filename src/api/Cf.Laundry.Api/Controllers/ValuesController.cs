using AutoMapper;
using Cf.Libs.Core.Infrastructure.Engine;
using Cf.Libs.Service.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Cf.Laundry.Api.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("index")]
        public object Get()
        {
            var mapper = EngineContext.Current.Resolve<IMapper>();
            return new { code = mapper.ToString() };
        }
    }
}
