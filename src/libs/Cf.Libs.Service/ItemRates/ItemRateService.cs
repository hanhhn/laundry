using AutoMapper;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Repository.ItemRates;
using Cf.Libs.DataAccess.Repository.Items;
using Cf.Libs.Service.Dtos.ItemRate;
using System;
using System.Linq;

namespace Cf.Libs.Service.ItemRates
{
    public class ItemRateService : BaseService, IItemRateService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemRateRepository _rateRepository;

        public ItemRateService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IItemRepository itemRepository,
            IItemRateRepository rateRepository) : base(unitOfWork, mapper)
        {
            _rateRepository = rateRepository;
            _itemRepository = itemRepository;
        }

        public ItemRateDto Add(ItemRateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            var rate = _mapper.Map<ItemRate>(request);
            var record = _rateRepository.Add(rate);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return _mapper.Map<ItemRateDto>(record);
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

            return _mapper.Map<ItemRateDto>(record);
        }

        public bool Delete(int id)
        {
            var record = _rateRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            _rateRepository.Delete(record);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }

        public ItemRateDto Get(int Id)
        {
            var rateQuery = from rate in _rateRepository.GetQuery()
                            where rate.Id == Id && !rate.IsDeleted
                            select rate;
            var itemQuery = from item in _itemRepository.GetQuery()
                            select item;

            var record = (from rate in rateQuery
                          join item in itemQuery on rate.ItemId equals item.Id
                          select new ItemRateDto
                          {
                              Id = rate.Id,
                              ItemId = item.Id,
                              ItemName = item.Name,
                              Rate = rate.Rate,
                              Tax = rate.Tax,
                              Discount = rate.Discount,
                              Priority = rate.Priority,
                              IsActive = rate.IsActive,
                              DiscountRate = rate.DiscountRate,
                              ApplyDate = rate.ApplyDate,
                              ExpireDate = rate.ExpireDate
                          }).SingleOrDefault();

            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            return _mapper.Map<ItemRateDto>(record);
        }

        public IPagedList<ItemRateDto> GetAll(int pageIndex, int pageSize)
        {
            var rateQuery = from rate in _rateRepository.GetQuery()
                            orderby rate.ApplyDate descending
                            orderby rate.ModifiedDate descending
                            orderby rate.CreateDate descending
                            orderby rate.Id ascending
                            where !rate.IsDeleted
                            select rate;
            var itemQuery = from item in _itemRepository.GetQuery()
                            select item;

            var query = from rate in rateQuery
                        join item in itemQuery on rate.ItemId equals item.Id
                        select new ItemRateDto
                        {
                            Id = rate.Id,
                            ItemId = item.Id,
                            ItemName = item.Name,
                            Rate = rate.Rate,
                            Tax = rate.Tax,
                            Discount = rate.Discount,
                            Priority = rate.Priority,
                            IsActive = rate.IsActive,
                            DiscountRate = rate.DiscountRate,
                            ApplyDate = rate.ApplyDate,
                            ExpireDate = rate.ExpireDate
                        };

            return query.ToPagedList(pageIndex, pageSize);
        }
    }
}