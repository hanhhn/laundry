using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Item;
using Cf.Libs.Service.Dtos.ItemRate;
using Cf.Libs.Service.ItemRates;
using Cf.Libs.Service.Items;
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
        [Route("add")]
        public ItemRateDto Add(ItemRateRequest request)
        {
            return _rateService.Add(request);
        }

        [HttpPost]
        [Route("edit")]
        public ItemRateDto Edit(ItemRateRequest request)
        {
            return _rateService.Edit(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            return _rateService.Delete(id);
        }
    }
}