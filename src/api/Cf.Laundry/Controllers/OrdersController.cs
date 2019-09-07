using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Method;
using Cf.Libs.Service.Methods;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cf.Laundry.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMethodService _methodService;

        public OrdersController(IMethodService methodService)
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
        [Route("apply")]
        public IPagedList<MethodDto> GetApply(int pageIndex = 0, int pageSize = 10)
        {
            return _methodService.GetApplyMethod(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("clean")]
        public IPagedList<MethodDto> GetClean(int pageIndex = 0, int pageSize = 10)
        {
            return _methodService.GetCleanMethod(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("soft")]
        public IPagedList<MethodDto> GetSoft(int pageIndex = 0, int pageSize = 10)
        {
            return _methodService.GetSoftMethod(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("dry")]
        public IPagedList<MethodDto> GetDry(int pageIndex = 0, int pageSize = 10)
        {
            return _methodService.GetDryMethod(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("straight")]
        public IPagedList<MethodDto> GetStraight(int pageIndex = 0, int pageSize = 10)
        {
            return _methodService.GetStraightMethod(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("delivery")]
        public IPagedList<MethodDto> GetDelivery(int pageIndex = 0, int pageSize = 10)
        {
            return _methodService.GetDeliveryMethod(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("get")]
        public IPagedList<MethodDto> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            return _methodService.GetAll(pageIndex, pageSize);
        }

        [HttpPost]
        [Route("save")]
        public MethodDto SaveMethod(MethodRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            if (request.Id > 0)
            {
                return _methodService.Edit(request);
            }
            return _methodService.Add(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            return _methodService.Delete(id);
        }
    }
}