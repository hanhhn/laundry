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

        [HttpPost]
        [Route("save")]
        public ItemDto Save(ItemRequest request)
        {
            if(request.Id > 0)
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
    }
}