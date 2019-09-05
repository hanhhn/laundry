using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Prices;

namespace Cf.Libs.Service.Prices
{
    public interface IPriceService
    {
        PriceDto Add(PriceRequest request);
        PriceDto Edit(PriceRequest request);
        bool Delete(int id);
        PriceDto Get(int Id);
        IPagedList<PriceDto> GetAll(int pageIndex, int pageSize);
    }
}