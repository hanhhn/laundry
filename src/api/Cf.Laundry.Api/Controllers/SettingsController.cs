using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Method;
using Cf.Libs.Service.Dtos.Setting;
using Cf.Libs.Service.Methods;
using Cf.Libs.Service.Settings;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cf.Laundry.Api.Controllers
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
        [Route("companyinfo")]
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
        [Route("reason")]
        public ReasonDto GetReason()
        {
            return _settingService.Get<ReasonDto>(SettingKey.Reason);
        }

        [HttpPost]
        [Route("reason/save")]
        public bool SaveReason(ReasonDto request)
        {
            return _settingService.Save(SettingKey.Reason, request);
        }

        [HttpGet]
        [Route("jumbotron")]
        public JumbotronDto GetJumbotron()
        {
            return _settingService.Get<JumbotronDto>(SettingKey.Jumbotron);
        }

        [HttpPost]
        [Route("jumbotron/save")]
        public bool SaveJumbotron(JumbotronDto request)
        {
            return _settingService.Save(SettingKey.Jumbotron, request);
        }

        [HttpGet]
        [Route("process")]
        public string[] GetProcessPost()
        {
            return _settingService.Get(SettingKey.Process);
        }

        [HttpPost]
        [Route("process/save")]
        public bool SaveProcessPost(string[] request)
        {
            return _settingService.Save(SettingKey.Process, request);
        }

        [HttpGet]
        [Route("guide")]
        public GuideDto GetGuide()
        {
            return _settingService.Get<GuideDto>(SettingKey.Guide);
        }

        [HttpPost]
        [Route("guide/save")]
        public bool SaveGuide(GuideDto request)
        {
            return _settingService.Save(SettingKey.Guide, request);
        }

        [HttpGet]
        [Route("combo")]
        public JumbotronDto GetItemCombo()
        {
            return _settingService.Get<JumbotronDto>(SettingKey.Combo);
        }

        [HttpPost]
        [Route("combo/save")]
        public bool SaveItemCombo(JumbotronDto request)
        {
            return _settingService.Save(SettingKey.Combo, request);
        }
    }
}