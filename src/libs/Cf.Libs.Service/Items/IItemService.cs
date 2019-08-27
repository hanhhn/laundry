using Cf.Libs.Core.BaseObject;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Item;

namespace Cf.Libs.Service.Items
{
    public interface IItemService : IBaseService
    {
        Result<ItemDto> Add(ItemRequest request);
        Result<ItemDto> Edit(ItemRequest request);
        Result<bool> Delete(int id);
    }
}