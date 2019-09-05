using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Prices;
using Cf.Libs.Service.Prices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cf.Laundry.Controllers
{
    [Route("api/prices")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService _rateService;

        public PricesController(IPriceService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public PriceDto Get(int id)
        {
            return _rateService.Get(id);
        }

        [HttpGet]
        [Route("get")]
        public IPagedList<PriceDto> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            return _rateService.GetAll(pageIndex, pageSize);
        }

        [HttpPost]
        [Route("save")]
        public PriceDto Save(PriceRequest request)
        {
            if(request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            if(request.Id > 0)
            {
                return _rateService.Edit(request);
            }
            return _rateService.Add(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            return _rateService.Delete(id);
        }
    }
}