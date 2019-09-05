using AutoMapper;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Repository.Items;
using Cf.Libs.DataAccess.Repository.Prices;
using Cf.Libs.Service.Dtos.Item;
using System;
using System.Linq;

namespace Cf.Libs.Service.Items
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IPriceRepository _priceRepository;

        public ItemService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IItemRepository itemRepository,
            IPriceRepository priceRepository) : base(unitOfWork, mapper)
        {
            _itemRepository = itemRepository;
            _priceRepository = priceRepository;
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
            return GetItemByType(pageIndex, pageSize);
        }

        public IPagedList<ItemDto> GetLaundry(int pageIndex, int pageSize)
        {
            return GetItemByType(pageIndex, pageSize, ItemType.Laundry.ToString());
        }

        public IPagedList<ItemDto> GetDryClean(int pageIndex, int pageSize)
        {
            return GetItemByType(pageIndex, pageSize, ItemType.DryClean.ToString());
        }

        private IPagedList<ItemDto> GetItemByType(int pageIndex, int pageSize, string type = null)
        {

            var itemQuery = from item in _itemRepository.GetQuery()
                            orderby item.SortOrder ascending
                            orderby item.Name ascending
                            orderby item.ModifiedDate ascending
                            orderby item.CreateDate ascending
                            where !item.IsDeleted
                            select item;

            if (!string.IsNullOrEmpty(type))
            {
                itemQuery = from item in itemQuery
                            where item.Type == type
                            select item;
            }

            var priceQuery = from rate in _priceRepository.GetQuery()
                            where !rate.IsDeleted && DateTime.Now > rate.ApplyDate
                            orderby rate.ApplyDate descending
                            orderby rate.Priority ascending
                            group rate by rate.ItemId into gRate
                            select gRate.FirstOrDefault();

            var query = from i in itemQuery
                        join r in priceQuery on i.Id equals r.ItemId into groupItem
                        from g in groupItem.DefaultIfEmpty(new Price())
                        select new ItemDto
                        {
                            Id = i.Id,
                            Image = i.Image,
                            Name = i.Name,
                            Description = i.Description,
                            Highlight = i.Highlight,
                            SortOrder = i.SortOrder,
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
            record.Highlight = request.Highlight;
            record.SortOrder = request.SortOrder;
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