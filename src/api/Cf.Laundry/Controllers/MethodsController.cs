using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Method;
using Cf.Libs.Service.Methods;
using Microsoft.AspNetCore.Mvc;

namespace Cf.Laundry.Controllers
{
    [Route("api/methods")]
    [ApiController]
    public class MethodsController : ControllerBase
    {
        private readonly IMethodService _methodService;

        public MethodsController(IMethodService methodService)
        {
            _methodService = methodService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public MethodDto Get(int id)
        {
            return _methodService.Get(id);
        }

        [HttpGet]
        [Route("get")]
        public IPagedList<MethodDto> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            return _methodService.GetAll(pageIndex, pageSize);
        }

        [HttpPost]
        [Route("add")]
        public MethodDto Add(MethodRequest request)
        {
            return _methodService.Add(request);
        }

        [HttpPost]
        [Route("edit")]
        public MethodDto Edit(MethodRequest request)
        {
            return _methodService.Edit(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            return _methodService.Delete(id);
        }
    }
}