using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Service;

namespace Cf.Libs.Service.Settings
{
    public interface ISettingService : IBaseService
    {
        T Get<T>(SettingKey settingKey) where T : class, new();
        bool Save<T>(SettingKey key, T model) where T : class, new();
        string[] Get(SettingKey settingKey);
        bool Save(SettingKey key, string[] model);
        bool Delete(SettingKey settingKey);
        bool Remove(int id);
    }
}