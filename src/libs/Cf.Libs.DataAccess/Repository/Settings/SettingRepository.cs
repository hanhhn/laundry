using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Configuration;
using System.Linq;

namespace Cf.Libs.DataAccess.Repository.Settings
{
    public class SettingRepository : BaseRepository<Setting>, ISettingRepository
    {
        public SettingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Setting FindByKey(string key)
        {
            return DbSet.Where(x => x.Name == key).SingleOrDefault();
        }
    }
}