using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Item;
using Cf.Libs.Service.Items;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cf.Laundry.Api.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public ItemDto Get(int id)
        {
            return _itemService.Get(id);
        }

        [HttpGet]
        [Route("get")]
        public IPagedList<ItemDto> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            return _itemService.GetAll(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("laundry")]
        public IPagedList<ItemDto> GetLaundry(int pageIndex = 0, int pageSize = 10)
        {
            return _itemService.GetLaundry(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("combo")]
        public IPagedList<ItemDto> GetCombo(int pageIndex = 0, int pageSize = 10)
        {
            return _itemService.GetCombo(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("price")]
        public IPagedList<ItemDto> GetPriceList(int pageIndex = 0, int pageSize = 10)
        {
            return _itemService.GetPriceList(pageIndex, pageSize);
        }

        [HttpPost]
        [Route("save")]
        public ItemDto Save(ItemRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            if (request.Id > 0)
            {
                return _itemService.Edit(request);
            }
            return _itemService.Add(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            return _itemService.Delete(id);
        }

        [HttpGet]
        [Route("itemcombo")]
        public ItemCombo GetItemCombo()
        {
            return _itemService.GetItemCombo();
        }
    }
}