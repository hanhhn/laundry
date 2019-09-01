using AutoMapper;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Repository.Methods;
using Cf.Libs.Service.Dtos.Method;

namespace Cf.Libs.Service.Methods
{
    public class MethodService : BaseService, IMethodService
    {
        private readonly IMethodRepository _methodRepository;

        public MethodService(
            IUnitOfWork unitOfWork,
            IMapper mapper, 
            IMethodRepository methodRepository) : base(unitOfWork, mapper)
        {
            _methodRepository = methodRepository;
        }

        public MethodDto Get(int Id)
        {
            var record = _methodRepository.Get(Id);
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            return _mapper.Map<MethodDto>(record);
        }

        public IPagedList<MethodDto> GetAll(int pageIndex, int pageSize)
        {
            var records = _methodRepository.GetQuery().ToPagedList<Method, MethodDto>(pageIndex, pageSize);

            return records;
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
            record.Discount = request.Discount;
            record.EnableDiscount = request.EnableDiscount;
            record.Type = request.Type;

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

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return true;
        }
    }
}