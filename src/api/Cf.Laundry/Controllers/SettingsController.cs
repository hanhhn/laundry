using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Method;
using Cf.Libs.Service.Dtos.Setting;
using Cf.Libs.Service.Methods;
using Cf.Libs.Service.Settings;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cf.Laundry.Controllers
{
    [Route("api/settings")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            return _settingService.Remove(id);
        }

        [HttpGet]
        [Route("companyinfo/get")]
        public CompanyInfoDto GetCompanyInfo()
        {
            return _settingService.Get<CompanyInfoDto>(SettingKey.Company);
        }

        [HttpPost]
        [Route("companyinfo/save")]
        public bool SaveCompanyInfo(CompanyInfoDto request)
        {
            return _settingService.Save(SettingKey.Company, request);
        }

        [HttpGet]
        [Route("externallink/get")]
        public LinkDto GetExternalLink()
        {
            return _settingService.Get<LinkDto>(SettingKey.Link);
        }

        [HttpPost]
        [Route("companyinfo/save")]
        public bool SaveExternalLink(LinkDto request)
        {
            return _settingService.Save(SettingKey.Link, request);
        }
    }
}