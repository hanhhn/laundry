using Cf.Libs.Service.Account;
using Cf.Libs.Service.Dtos.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cf.Laundry.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("signin")]
        public async Task<bool> SigninAsync(SigninDto model)
        {
            if(ModelState.IsValid)
            {
                return await _service.SigninAsyn(model);
            }
            return false;
        }

        [HttpGet]
        [Route("signup")]
        public async Task<bool> SignupAsync(SignupDto model)
        {
            if (ModelState.IsValid)
            {
                return await _service.SignupAsyn(model);
            }
            return false;
        }
    }
}