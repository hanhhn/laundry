using AutoMapper;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Repository.Methods;
using Cf.Libs.DataAccess.Repository.Prices;
using Cf.Libs.Service.Dtos.Method;
using System;
using System.Linq;

namespace Cf.Libs.Service.Methods
{
    public class MethodService : BaseService, IMethodService
    {
        private readonly IMethodRepository _methodRepository;
        private readonly IPriceRepository _priceRepository;

        public MethodService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMethodRepository methodRepository,
            IPriceRepository priceRepository) : base(unitOfWork, mapper)
        {
            _methodRepository = methodRepository;
            _priceRepository = priceRepository;
        }

        public MethodDto Get(int Id)
        {
            var record = _methodRepository.Get(Id);
            return _mapper.Map<MethodDto>(record);
        }

        public IPagedList<MethodDto> GetApplyMethod(int pageIndex, int pageSize)
        {
            return GetMethodByType(pageIndex, pageSize);
        }

        public IPagedList<MethodDto> GetAll(int pageIndex, int pageSize)
        {
            return _methodRepository.FindBy(x => !x.IsDeleted).ToPagedList<Method, MethodDto>(pageIndex, pageSize);
        }

        private IPagedList<MethodDto> GetMethodByType(int pageIndex, int pageSize, string type = null)
        {
            var methodQuery = from item in _methodRepository.GetQuery()
                              orderby item.SortOrder ascending
                              orderby item.Name ascending
                              orderby item.ModifiedDate ascending
                              orderby item.CreateDate ascending
                              where !item.IsDeleted
                              select item;

            if (!string.IsNullOrEmpty(type))
            {
                methodQuery = from item in methodQuery
                              where item.Type == type
                              select item;
            }

            var priceQuery = from rate in _priceRepository.GetQuery()
                             where !rate.IsDeleted && DateTime.Now > rate.ApplyDate
                             orderby rate.ApplyDate descending
                             orderby rate.Priority ascending
                             group rate by rate.ItemId into gRate
                             select gRate.FirstOrDefault();

            var query = from i in methodQuery
                        join r in priceQuery on i.Id equals r.ItemId into groupItem
                        from g in groupItem.DefaultIfEmpty(new Price())
                        select new MethodDto
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Description = i.Description,
                            SortOrder = i.SortOrder,
                            Type = i.Type,
                            Unit = i.Unit,
                            Rate = g.Rate,
                            Tax = g.Tax,
                            Discount = g.Discount,
                            DiscountRate = g.DiscountRate,
                            EnableDiscount = i.EnableDiscount,
                        };

            return query.ToPagedList(pageIndex, pageSize);
        }

        public MethodDto Add(MethodRequest request)
        {
            var item = _mapper.Map<Method>(request);
            var record = _methodRepository.Add(item);
            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return _mapper.Map<MethodDto>(record);
        }

        public MethodDto Edit(MethodRequest request)
        {
            var record = _methodRepository.Get(request.Id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            record.Name = request.Name;
            record.Description = request.Description;
            record.EnableDiscount = request.EnableDiscount;
            record.Type = request.Type;
            record.Unit = request.Unit;

            _methodRepository.Update(record);

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return _mapper.Map<MethodDto>(record);
        }

        public bool Delete(int id)
        {

            var record = _methodRepository.Get(id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            _methodRepository.Delete(record);

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }
    }
}