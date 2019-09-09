using AutoMapper;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Configuration;
using Cf.Libs.DataAccess.Repository.Settings;
using Newtonsoft.Json;

namespace Cf.Libs.Service.Settings
{
    public class SettingService : BaseService, ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ISettingRepository settingRepository) : base(unitOfWork, mapper)
        {
            _settingRepository = settingRepository;
        }

        public T Get<T>(SettingKey settingKey) where T : class
        {
            var record = _settingRepository.FindByKey(settingKey.ToString());
            return JsonConvert.DeserializeObject<T>(record.Value);
        }

        public bool Save<T>(SettingKey key, T model) where T : class
        {
            var record = _settingRepository.FindByKey(SettingKey.Company.ToString());
            var setting = JsonConvert.SerializeObject(record.Value);

            if (record == null)
            {
                _settingRepository.Add(new Setting
                {
                    Name = key.ToString(),
                    Value = setting
                });
            }

            record.Value = setting;
            _settingRepository.Update(record);

            return _unitOfWork.SaveChanges() != 0;
        }

        public bool Delete(SettingKey settingKey)
        {
            var record = _settingRepository.FindByKey(settingKey.ToString());
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            _settingRepository.Delete(record);
            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            var record = _settingRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            _settingRepository.Remove(record);
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}