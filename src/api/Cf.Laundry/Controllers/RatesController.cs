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
        [Route("all")]
        public IPagedList<ItemRateDto> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            return _rateService.GetAll(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("get/{id}")]
        public ItemRateDto GetItem(int id)
        {
            return _rateService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ItemRateDto AddItem(ItemRateRequest request)
        {
            return _rateService.Add(request);
        }

        [HttpPost]
        [Route("edit")]
        public ItemRateDto EditItem(ItemRateRequest request)
        {
            return _rateService.Edit(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteItem(int id)
        {
            return _rateService.Delete(id);
        }
    }
}