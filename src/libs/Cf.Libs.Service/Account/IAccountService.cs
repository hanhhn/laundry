﻿using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Account;
using System.Threading.Tasks;

namespace Cf.Libs.Service.Account
{
    public interface IAccountService : IBaseService
    {
        Task<bool> SigninAsyn(SigninDto model);
        Task<bool> SignupAsyn(SignupDto model);
    }
}