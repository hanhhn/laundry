using AutoMapper;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Common;
using Cf.Libs.DataAccess.Repository.Addresses;
using Cf.Libs.DataAccess.Repository.Districts;
using Cf.Libs.DataAccess.Repository.Provinces;
using Cf.Libs.DataAccess.Repository.Wards;
using Cf.Libs.Service.Dtos.Adress;
using System.Collections.Generic;
using System.Linq;

namespace Cf.Libs.Service.Addresses
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

        public IEnumerable<AddressDto> GetFullAddress(string phone)
        {
            if(string.IsNullOrEmpty(phone))
            {
                throw new InformationException("Param is invalid.");
            }

            var records = _addressRepository.FindByPhone(phone);

            return _mapper.Map<IEnumerable<AddressDto>>(records.ToList());
        }

        public IEnumerable<AddressDto> Add(AddressRequest request)
        {
            var province = _provinceRepository.Get(request.ProvinceId);
            var district = _districtRepository.Get(request.DistrictId);
            var ward = _wardRepository.Get(request.WardId);

            var address = _mapper.Map<Address>(request);
            address.Province = string.Format("{0} {1}", province.Prefix, province.Name).Trim();
            address.District = string.Format("{0} {1}", district.Prefix, district.Name).Trim();
            address.Ward = string.Format("{0} {1}", ward.Prefix, ward.Name).Trim();

            var record = _addressRepository.Add(address);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            var records = _addressRepository.FindByPhone(request.Phone);
            return _mapper.Map<IEnumerable<AddressDto>>(records.ToList());
        }

        public IEnumerable<AddressDto> Edit(AddressRequest request)
        {
            var record = _addressRepository.Get(request.Id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            //record.Phone = request.Phone;
            record.FullName = request.FullName;
            record.IsDefault = request.IsDefault;
            record.ProvinceId = request.ProvinceId;
            record.Province = request.Province;
            record.DistrictId = request.DistrictId;
            record.District = request.District;
            record.WardId = request.WardId;
            record.Ward = request.Ward;
            record.Street = request.Street;
            _addressRepository.Update(record);

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            var records = _addressRepository.FindByPhone(request.Phone);
            return _mapper.Map<IEnumerable<AddressDto>>(records.ToList());
        }

        public IEnumerable<AddressDto> Delete(int id)
        {
            var record = _addressRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            _addressRepository.Delete(record);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            var records = _addressRepository.FindByPhone(record.Phone);
            return _mapper.Map<IEnumerable<AddressDto>>(records.ToList());
        }

        public bool SetDefault(string phone, int id)
        {
            var record = _addressRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            var address = _addressRepository.FindByPhone(phone).ToList();
            foreach (var item in address)
            {
                item.IsDefault = false;
                _addressRepository.Update(item);
            }
            record.IsDefault = true;
            _addressRepository.Update(record);

            if (_unitOfWork.SaveChanges() != address.Count + 1)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }
    }
}