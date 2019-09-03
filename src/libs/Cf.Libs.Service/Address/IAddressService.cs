using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Adresss;
using System.Collections.Generic;

namespace Cf.Libs.Service.Address
{
    public interface IAddressService : IBaseService
    {
        IEnumerable<AddressUnitDto> GetProvince();
        IEnumerable<AddressUnitDto> GetDistrict(int provinceId);
        IEnumerable<AddressUnitDto> GetWard(int districtId);
    }
}