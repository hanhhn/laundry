using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Service;

namespace Cf.Libs.Service.Settings
{
    public interface ISettingService : IBaseService
    {
        T Get<T>(SettingKey settingKey) where T : class;
        bool Save<T>(SettingKey key, T model) where T : class;
        bool Delete(SettingKey settingKey);
        bool Remove(int id);
    }
}