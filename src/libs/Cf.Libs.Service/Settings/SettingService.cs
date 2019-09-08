using AutoMapper;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Configuration;
using Cf.Libs.DataAccess.Repository.Settings;
using Cf.Libs.Service.Dtos.Setting;
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

        public CompanyInfoDto Get(SettingKey settingKey)
        {
            var record = _settingRepository.FindByKey(settingKey.ToString());
            return JsonConvert.DeserializeObject<CompanyInfoDto>(record.Value);
        }

        public bool SaveCompanyInfo(CompanyInfoDto model)
        {
            var record = _settingRepository.FindByKey(SettingKey.Company.ToString());
            var setting = JsonConvert.SerializeObject(record.Value);

            if (record == null)
            {
                _settingRepository.Add(new Setting
                {
                    Name = SettingKey.Company.ToString(),
                    Value = setting
                });
            }

            record.Value = setting;
            _settingRepository.Update(record);

            return _unitOfWork.SaveChanges() != 0;
        }


        public bool SaveExternalLink(LinkDto model)
        {
            var record = _settingRepository.FindByKey(SettingKey.Link.ToString());
            var setting = JsonConvert.SerializeObject(record.Value);

            if (record == null)
            {
                _settingRepository.Add(new Setting
                {
                    Name = SettingKey.Link.ToString(),
                    Value = setting
                });
            }

            record.Value = setting;
            _settingRepository.Update(record);

            return _unitOfWork.SaveChanges() != 0;
        }
    }
}