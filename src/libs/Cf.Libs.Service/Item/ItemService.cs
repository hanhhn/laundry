using AutoMapper;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;

namespace Cf.Libs.Service.Item
{
    public class ItemService : BaseService, IItemService
    {
        public ItemService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}