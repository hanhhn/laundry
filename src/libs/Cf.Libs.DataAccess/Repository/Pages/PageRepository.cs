using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Static;
using System.Linq;

namespace Cf.Libs.DataAccess.Repository.Pages
{
    public class PageRepository : BaseRepository<Page>, IPageRepository
    {
        public PageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Page GetByUrl(string url)
        {
            return DbSet.Where(x => x.UniqueUrl == url).SingleOrDefault();
        }
    }
}