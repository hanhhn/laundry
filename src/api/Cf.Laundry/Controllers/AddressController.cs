using Cf.Libs.Service.Address;
using Cf.Libs.Service.Dtos.Adresss;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cf.Laundry.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [Route("get/province")]
        public IEnumerable<AddressUnitDto> GetProvince()
        {
            return _addressService.GetProvince();
        }

        [HttpGet]
        [Route("get/district/{id}")]
        public IEnumerable<AddressUnitDto> GetDistrict(int id)
        {
            return _addressService.GetDistrict(id);
        }

        [HttpGet]
        [Route("get/ward/{id}")]
        public IEnumerable<AddressUnitDto> GetWard(int id)
        {
            return _addressService.GetWard(id);
        }
    }
}