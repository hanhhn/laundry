using AutoMapper;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Repository.Addresses;
using Cf.Libs.DataAccess.Repository.Districts;
using Cf.Libs.DataAccess.Repository.Provinces;
using Cf.Libs.DataAccess.Repository.Wards;
using Cf.Libs.Service.Dtos.Adresss;
using System.Collections.Generic;
using System.Linq;

namespace Cf.Libs.Service.Address
{
    public class AddressService : BaseService, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IWardRepository _wardRepository;

        public AddressService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAddressRepository addressRepository,
            IProvinceRepository provinceRepository,
            IDistrictRepository districtRepository,
            IWardRepository wardRepository) : base(unitOfWork, mapper)
        {
            _addressRepository = addressRepository;
            _provinceRepository = provinceRepository;
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
        }

        public IEnumerable<AddressUnitDto> GetProvince()
        {
            var query = from item in _provinceRepository.GetQuery()
                        where !item.IsDeleted && item.IsPublished
                        orderby item.SortOrder ascending
                        orderby item.Name ascending
                        select item;
            return _mapper.Map<IEnumerable<AddressUnitDto>>(query.ToList());
        }

        public IEnumerable<AddressUnitDto> GetDistrict(int provinceId)
        {
            var query = from item in _districtRepository.GetQuery()
                        where !item.IsDeleted && item.IsPublished
                            && item.ProvinceId == provinceId
                        orderby item.SortOrder ascending
                        orderby item.Name ascending
                        select item;

            return _mapper.Map<IEnumerable<AddressUnitDto>>(query.ToList());
        }

        public IEnumerable<AddressUnitDto> GetWard(int districtId)
        {
            var query = from item in _wardRepository.GetQuery()
                        where !item.IsDeleted && item.IsPublished
                            && item.DistrictId == districtId
                        orderby item.SortOrder ascending
                        orderby item.Name ascending
                        select item;

            return _mapper.Map<IEnumerable<AddressUnitDto>>(query.ToList());
        }
    }
}