using AutoMapper;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Repository.Items;
using Cf.Libs.DataAccess.Repository.Methods;
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
        private readonly IMethodRepository _methodRepository;

        public ItemService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IItemRepository itemRepository,
            IPriceRepository priceRepository,
            IMethodRepository methodRepository) : base(unitOfWork, mapper)
        {
            _itemRepository = itemRepository;
            _priceRepository = priceRepository;
            _methodRepository = methodRepository;
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

            var methodQuery = from method in _methodRepository.GetQuery()
                              where !method.IsDeleted
                              select method;

            var priceQuery = from rate in _priceRepository.GetQuery()
                            where !rate.IsDeleted && DateTime.Now > rate.ApplyDate
                            orderby rate.ApplyDate descending
                            orderby rate.Priority ascending
                            group rate by rate.ItemId into gRate
                            select gRate.FirstOrDefault();

            var query = from i in itemQuery
                        join m in methodQuery on i.Delivery equals m.Id into groupMethod
                        join r in priceQuery on i.Id equals r.ItemId into groupItem
                        from gr in groupItem.DefaultIfEmpty(new Price())
                        from gm in groupMethod.DefaultIfEmpty(new Method())
                        select new ItemDto
                        {
                            Id = i.Id,
                            Image = i.Image,
                            Name = i.Name,
                            Description = i.Description,
                            Highlight = i.Highlight,
                            SortOrder = i.SortOrder,
                            Type = i.Type,
                            Rate = gr.Rate,
                            Discount = gr.Discount,
                            DiscountRate = gr.DiscountRate,
                            Tax = gr.Tax,
                            DeliveryId = gm.Id,
                            DeliveryName = gm.Name,
                            DeliveryDescription = gm.Description
                        };

            return query.ToPagedList(pageIndex, pageSize);
        }

        public ItemDto Add(ItemRequest request)
        {
            var item = _mapper.Map<Item>(request);
            var delivery = _methodRepository.Get(request.DeliveryId);
            if(delivery == null || delivery.Type != MethodType.Delivery.ToString())
            {
                throw new InformationException("Delivery method can not be found.");
            }

            item.Delivery = delivery.Id;
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
            var delivery = _methodRepository.Get(request.DeliveryId);
            if (delivery == null || delivery.Type != MethodType.Delivery.ToString())
            {
                throw new InformationException("Delivery method not be found.");
            }

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
            record.Delivery = delivery.Id;

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