using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Item;
using Cf.Libs.Service.Items;
using Microsoft.AspNetCore.Mvc;

namespace Cf.Laundry.Controllers
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
        [Route("all")]
        public IPagedList<ItemDto> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            return _itemService.GetAll(pageIndex, pageSize);
        }

        [HttpGet]
        [Route("get/{id}")]
        public ItemDto GetItem(int id)
        {
            return _itemService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ItemDto AddItem(ItemRequest request)
        {
            return _itemService.Add(request);
        }

        [HttpPost]
        [Route("edit")]
        public ItemDto EditItem(ItemRequest request)
        {
            return _itemService.Edit(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteItem(int id)
        {
            return _itemService.Delete(id);
        }
    }
}