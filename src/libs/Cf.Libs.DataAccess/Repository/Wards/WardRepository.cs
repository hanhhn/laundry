using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Common;

namespace Cf.Libs.DataAccess.Repository.Wards
{
    public class WardRepository : BaseRepository<Ward>, IWardRepository
    {
        public WardRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}