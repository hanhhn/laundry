using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.ItemRate;
using Cf.Libs.Service.ItemRates;
using Microsoft.AspNetCore.Mvc;

namespace Cf.Laundry.Controllers
{
    [Route("api/rates")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IItemRateService _rateService;

        public RatesController(IItemRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public ItemRateDto Get(int id)
        {
            return _rateService.Get(id);
        }

        [HttpGet]
        [Route("get")]
        public IPagedList<ItemRateDto> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            return _rateService.GetAll(pageIndex, pageSize);
        }

        [HttpPost]
        [Route("save")]
        public ItemRateDto Save(ItemRateRequest request)
        {
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