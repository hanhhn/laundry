using AutoMapper;
using Cf.Laundry.Common;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Repository.Items;
using Cf.Libs.DataAccess.Repository.Methods;
using Cf.Libs.DataAccess.Repository.Prices;
using Cf.Libs.Service.Dtos.Price;
using System;
using System.Linq;

namespace Cf.Libs.Service.Prices
{
    public class PricesService : BaseService, IPriceService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMethodRepository _methodRepository;
        private readonly IPriceRepository _priceRepository;

        public PricesService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IItemRepository itemRepository,
            IMethodRepository methodRepository,
            IPriceRepository priceRepository) : base(unitOfWork, mapper)
        {
            _priceRepository = priceRepository;
            _itemRepository = itemRepository;
            _methodRepository = methodRepository;
        }

        public PriceDto Add(PriceRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            var rate = _mapper.Map<Price>(request);
            rate.DiscountRate = rate.Rate * (rate.Discount / 100 + 1);
            var record = _priceRepository.Add(rate);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return _mapper.Map<PriceDto>(record);
        }

        public PriceDto Edit(PriceRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            var record = _priceRepository.Get(request.Id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            record.ItemId = request.ItemId;
            record.ItemCode = request.ItemCode;
            record.Rate = request.Rate;
            record.Tax = request.Tax;
            record.DiscountRate = request.DiscountRate;
            record.Discount = request.Discount;
            record.Priority = request.Priority;
            record.IsActive = request.IsActive;
            record.ApplyDate = request.ApplyDate;
            record.ExpireDate = request.ExpireDate;

            _priceRepository.Update(record);

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return _mapper.Map<PriceDto>(record);
        }

        public bool Delete(int id)
        {
            var record = _priceRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            _priceRepository.Delete(record);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }

        public PriceDto Get(int Id)
        {
            var rateQuery = from rate in _priceRepository.GetQuery()
                            where rate.Id == Id && !rate.IsDeleted
                            select rate;

            var itemQuery = from item in _itemRepository.GetQuery()
                            select item;

            var record = (from rate in rateQuery
                          join item in itemQuery on rate.ItemId equals item.Id
                          select new PriceDto
                          {
                              Id = rate.Id,
                              ItemId = item.Id,
                              ItemCode = rate.ItemCode,
                              Rate = rate.Rate,
                              Tax = rate.Tax,
                              Discount = rate.Discount,
                              DiscountRate = rate.DiscountRate,
                              Priority = rate.Priority,
                              IsActive = rate.IsActive,
                              ApplyDate = rate.ApplyDate,
                              ExpireDate = rate.ExpireDate
                          }).SingleOrDefault();

            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            return _mapper.Map<PriceDto>(record);
        }

        public IPagedList<PriceDto> GetAll(int pageIndex, int pageSize)
        {

            var itemQuery = from price in _priceRepository.FindByItem()
                            join item in _itemRepository.GetQuery() on price.ItemId equals item.Id
                            select price;


            var methodQuery = from price in _priceRepository.FindByMethod()
                              join method in _methodRepository.GetQuery() on price.ItemId equals method.Id
                              select price;

            var query = from price in itemQuery.Union(methodQuery)
                        orderby price.ApplyDate descending
                        orderby price.ModifiedDate descending
                        orderby price.CreateDate descending
                        orderby price.Id ascending
                        select price;

            return query.ToPagedList<Price, PriceDto>(pageIndex, pageSize);
        }
    }
}