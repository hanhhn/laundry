﻿using AutoMapper;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Repository.Items;
using Cf.Libs.DataAccess.Repository.Methods;
using Cf.Libs.DataAccess.Repository.Prices;
using Cf.Libs.DataAccess.Repository.Settings;
using Cf.Libs.Service.Dtos.Item;
using Cf.Libs.Service.Dtos.Setting;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Cf.Libs.Service.Items
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IMethodRepository _methodRepository;
        private readonly ISettingRepository _settingRepository;

        public ItemService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IItemRepository itemRepository,
            IPriceRepository priceRepository,
            IMethodRepository methodRepository,
            ISettingRepository settingRepository) : base(unitOfWork, mapper)
        {
            _itemRepository = itemRepository;
            _priceRepository = priceRepository;
            _methodRepository = methodRepository;
            _settingRepository = settingRepository;
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
                        join m in methodQuery on i.Combo equals m.Id into groupMethod
                        join r in priceQuery on i.Id equals r.ItemId into groupPrice
                        from gr in groupPrice.DefaultIfEmpty(new Price())
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
                            ComboId = gm.Id,
                            ComboName = gm.Name,
                            ComboDescription = gm.Description
                        };

            return query.ToPagedList(pageIndex, pageSize);
        }

        public ItemDto Add(ItemRequest request)
        {
            var item = _mapper.Map<Item>(request);
            var delivery = _methodRepository.Get(request.ComboId);
            if (delivery == null || delivery.Type != MethodType.Combo.ToString())
            {
                throw new InformationException("Delivery method can not be found.");
            }

            item.Combo = delivery.Id;
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
            var combo = _methodRepository.Get(request.ComboId);
            if (combo == null || combo.Type != MethodType.Combo.ToString())
            {
                throw new InformationException("Combo method not be found.");
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
            record.Combo = combo.Id;

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

        public ItemCombo GetItemCombo()
        {
            var record = _settingRepository.FindByKey(SettingKey.Combo.ToString());

            JumbotronDto setting = new JumbotronDto();
            if (record != null && !string.IsNullOrEmpty(record.Value))
            {
                setting = JsonConvert.DeserializeObject<JumbotronDto>(record.Value);
            }

            var combo = GetLaundry(0, 3);

            var result = _mapper.Map<ItemCombo>(setting);
            result.Items = combo.DataSource;
            return result;
        }
    }
}