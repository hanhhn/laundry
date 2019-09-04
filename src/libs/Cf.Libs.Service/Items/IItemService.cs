using Cf.Libs.Core.BaseObject;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Item;

namespace Cf.Libs.Service.Items
{
    public interface IItemService : IBaseService
    {
        ItemDto Get(int Id);
        IPagedList<ItemDto> GetAll(int pageIndex, int pageSize);
        IPagedList<ItemDto> GetLaundry(int pageIndex, int pageSize);
        IPagedList<ItemDto> GetDryClean(int pageIndex, int pageSize);
        IPagedList<ItemDto> GetTransport(int pageIndex, int pageSize);
        ItemDto Add(ItemRequest request);
        ItemDto Edit(ItemRequest request);
        bool Delete(int id);
    }
}