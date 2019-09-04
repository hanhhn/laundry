﻿using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Adresss;
using System.Collections.Generic;

namespace Cf.Libs.Service.Address
{
    public interface IAddressService : IBaseService
    {
        IEnumerable<AddressUnitDto> GetProvince();
        IEnumerable<AddressUnitDto> GetDistrict(int provinceId);
        IEnumerable<AddressUnitDto> GetWard(int districtId);
        IEnumerable<AddressDto> GetFullAddress(string phone);
        IEnumerable<AddressDto> Add(AddressRequest request);
        IEnumerable<AddressDto> Edit(AddressRequest request);
        bool SetDefault(string phone, int id);
    }
}