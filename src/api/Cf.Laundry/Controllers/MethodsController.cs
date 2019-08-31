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
        [Route("all")]
        public IPagedList<MethodDto> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            return _methodService.GetAll(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("get/{id}")]
        public MethodDto GetItem(int id)
        {
            return _methodService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public MethodDto AddItem(MethodRequest request)
        {
            return _methodService.Add(request);
        }

        [HttpPost]
        [Route("edit")]
        public MethodDto EditItem(MethodRequest request)
        {
            return _methodService.Edit(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteItem(int id)
        {
            return _methodService.Delete(id);
        }
    }
}