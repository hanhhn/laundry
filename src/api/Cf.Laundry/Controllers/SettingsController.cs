﻿using Cf.Libs.Core.Enums;
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
        [Route("homepost")]
        public string[] GetHomePost()
        {
            return _settingService.Get(SettingKey.HomePost);
        }

        [HttpPost]
        [Route("homepost/save")]
        public bool SaveHomePost(string[] request)
        {
            return _settingService.Save(SettingKey.Jumbotron, request);
        }
    }
}