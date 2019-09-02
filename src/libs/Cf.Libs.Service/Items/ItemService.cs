using AutoMapper;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Repository.ItemRates;
using Cf.Libs.DataAccess.Repository.Items;
using Cf.Libs.Service.Dtos.Item;
using System;
using System.Linq;

namespace Cf.Libs.Service.Items
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemRateRepository _rateRepository;

        public ItemService(
            IUnitOfWork unitOfWork,
            IMapper mapper, 
            IItemRepository itemRepository,
            IItemRateRepository rateRepository) : base(unitOfWork, mapper)
        {
            _itemRepository = itemRepository;
            _rateRepository = rateRepository;
        }

        public ItemDto Get(int Id)
        {
            var record = _itemRepository.Get(Id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            return _mapper.Map<ItemDto>(record);
        }

        public IPagedList<ItemDto> GetAll(int pageIndex, int pageSize)
        {
            var itemQuery = from item in _itemRepository.GetQuery()
                            orderby item.Name ascending
                            orderby item.Order ascending
                            where !item.IsDeleted
                            select item;

            var rateQuery = from rate in _rateRepository.GetQuery()
                            where !rate.IsDeleted
                            orderby rate.ApplyDate descending
                            orderby rate.Priority ascending
                            group rate by rate.ItemId into gRate
                            select gRate.FirstOrDefault();

            var query = from i in itemQuery
                        join r in rateQuery on i.Id equals r.ItemId into groupItem
                        from g in groupItem.DefaultIfEmpty(new ItemRate())
                        select new ItemDto
                        {
                            Id = i.Id,
                            Image = i.Image,
                            Name = i.Name,
                            Description = i.Description,
                            Highlights = i.Highlights,
                            Order = i.Order,
                            Type = i.Type,
                            Rate = g.Rate,
                            Discount = g.Discount,
                            DiscountRate = g.DiscountRate,
                            Tax = g.Tax
                        };

            return query.ToPagedList(pageIndex, pageSize);
        }

        public ItemDto Add(ItemRequest request)
        {
            var item = _mapper.Map<Item>(request);
            var record = _itemRepository.Add(item);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return _mapper.Map<ItemDto>(record);
        }

        public ItemDto Edit(ItemRequest request)
        {
            var record = _itemRepository.Get(request.Id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            record.Image = request.Image;
            record.Name = request.Name;
            record.Description = request.Description;
            record.Highlights = request.Highlights;
            record.Order = request.Order;
            record.Type = request.Type;

            _itemRepository.Update(record);

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return _mapper.Map<ItemDto>(record);
        }

        public bool Delete(int id)
        {

            var record = _itemRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            _itemRepository.Delete(record);

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }
    }
}