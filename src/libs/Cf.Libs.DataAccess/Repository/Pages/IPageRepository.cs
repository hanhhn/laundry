using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.Entities.Static;

namespace Cf.Libs.DataAccess.Repository.Pages
{
    public interface IPageRepository : IBaseRepository<Page>
    {
        Page GetByUrl(string url);
    }
}