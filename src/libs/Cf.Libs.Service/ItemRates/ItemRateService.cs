using AutoMapper;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Repository.ItemRates;
using Cf.Libs.Service.Dtos.ItemRate;
using System;

namespace Cf.Libs.Service.ItemRates
{
    public class ItemRateService : BaseService, IItemRateService
    {
        private readonly IItemRateRepository _rateRepository;

        public ItemRateService(IUnitOfWork unitOfWork, IItemRateRepository rateRepository)
            : base(unitOfWork)
        {
            _rateRepository = rateRepository;
        }

        public ItemRateDto Add(ItemRateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            var rate = Mapper.Map<ItemRate>(request);
            var record = _rateRepository.Add(rate);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return Mapper.Map<ItemRateDto>(record);
        }

        public ItemRateDto Edit(ItemRateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            var record = _rateRepository.Get(request.Id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            record.ItemId = request.ItemId;
            record.Rate = request.Rate;
            record.Tax = request.Tax;
            record.DiscountRate = request.DiscountRate;
            record.Discount = request.Discount;
            record.Priority = request.Priority;
            record.IsActive = request.IsActive;
            record.ApplyDate = request.ApplyDate;
            record.ExpireDate = request.ExpireDate;

            _rateRepository.Update(record);

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return Mapper.Map<ItemRateDto>(record);
        }

        public bool Delete(int id)
        {
            var record = _rateRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }

        public ItemRateDto Get(int Id)
        {
            var record = _rateRepository.Get(Id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            return Mapper.Map<ItemRateDto>(record);
        }

        public IPagedList<ItemRateDto> GetAll(int pageIndex, int pageSize)
        {
            var records = _rateRepository.GetQuery().ToPagedList<ItemRate, ItemRateDto>(pageIndex, pageSize);

            return records;
        }
    }
}