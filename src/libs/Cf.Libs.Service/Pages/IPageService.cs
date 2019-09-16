using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Page;

namespace Cf.Libs.Service.Pages
{
    public interface IPageService : IBaseService
    {
        PageDto Get(string id);
        PageDto GetByUrl(string uniqueUrl);
        IPagedList<PageDto> GetAll(int pageIndex, int pageSize);
        bool IsUniqueUrl(string url);
        bool Save(PageRequest request);
        bool Delete(string id);
    }
}