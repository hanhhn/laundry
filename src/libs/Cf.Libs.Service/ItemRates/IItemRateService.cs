using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.ItemRate;

namespace Cf.Libs.Service.ItemRates
{
    public interface IItemRateService
    {
        ItemRateDto Add(ItemRateRequest request);
        ItemRateDto Edit(ItemRateRequest request);
        bool Delete(int id);
        ItemRateDto Get(int Id);
        IPagedList<ItemRateDto> GetAll(int pageIndex, int pageSize);
    }
}