using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Adress;
using System.Collections.Generic;

namespace Cf.Libs.Service.Addresses
{
    public interface IAddressService : IBaseService
    {
        IEnumerable<AddressUnitDto> GetProvince();
        IEnumerable<AddressUnitDto> GetDistrict(int provinceId);
        IEnumerable<AddressUnitDto> GetWard(int districtId);
        IEnumerable<AddressDto> GetFullAddress(string phone);
        IEnumerable<AddressDto> Add(AddressRequest request);
        IEnumerable<AddressDto> Edit(AddressRequest request);
        IEnumerable<AddressDto> Delete(int id);
        bool SetDefault(string phone, int id);
    }
}