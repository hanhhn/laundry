using AutoMapper;
using Cf.Libs.Core.BaseObject;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Items;
using Cf.Libs.DataAccess.Repository.Items;
using Cf.Libs.Service.Dtos.Item;

namespace Cf.Libs.Service.Items
{
    public class ItemService : BaseService, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IUnitOfWork unitOfWork, IItemRepository itemRepository) 
            : base(unitOfWork)
        {
            _itemRepository = itemRepository;
        }

        public Result<ItemDto> Add(ItemRequest request)
        {
            Result<ItemDto> result = new Result<ItemDto>();

            var item = Mapper.Map<Item>(request);
            var entity = _itemRepository.Add(item);
            if (_unitOfWork.SaveChanges() > 0)
            {
                result.Data = Mapper.Map<ItemDto>(entity);
            }
            else
            {
                result.Code = StatusCode.Error;
                result.Messages.Add(new Messages
                {
                    Type = MsgType.Error,
                    Content = "Xảy ra lỗi trong quá trình lưu dữ liệu."
                });
            }

            return result;
        }

        public Result<ItemDto> Edit(ItemRequest request)
        {
            Result<ItemDto> result = new Result<ItemDto>();

            var record = _itemRepository.Get(request.Id);
            if(record != null)
            {
                record.Image = request.Image;
                record.Name = request.Name;
                record.Description = request.Description;
                record.Highlights = request.Highlights;
                record.Order = request.Order;
                record.Type = request.Type;

                _itemRepository.Update(record);
            }

            if (_unitOfWork.SaveChanges() > 0)
            { 
                result.Data = Mapper.Map<ItemDto>(record);
            }
            else
            {
                result.Code = StatusCode.Error;
                result.Messages.Add(new Messages
                {
                    Type = MsgType.Error,
                    Content = "Xảy ra lỗi trong quá trình lưu dữ liệu."
                });
            }

            return result;
        }

        public Result<bool> Delete(int id)
        {
            Result<bool> result = new Result<bool>();

            var record = _itemRepository.Get(id);
            if (record != null)
            {
                _itemRepository.Delete(record);
            }

            if (_unitOfWork.SaveChanges() > 0)
            {
                result.Data = true;
            }
            else
            {
                result.Code = StatusCode.Error;
                result.Data = false;
                result.Messages.Add(new Messages
                {
                    Type = MsgType.Error,
                    Content = "Xảy ra lỗi trong quá trình xóa dữ liệu."
                });
            }

            return result;
        }
    }
}