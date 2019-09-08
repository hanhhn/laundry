using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.Entities.Configuration;

namespace Cf.Libs.DataAccess.Repository.Settings
{
    public interface ISettingRepository : IBaseRepository<Setting>
    {
        Setting FindByKey(string key);
    }
}