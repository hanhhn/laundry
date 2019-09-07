using AutoMapper;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Repository.Items;
using Cf.Libs.DataAccess.Repository.Methods;
using Cf.Libs.DataAccess.Repository.OrderDetails;
using Cf.Libs.DataAccess.Repository.Orders;
using Cf.Libs.DataAccess.Repository.Prices;

namespace Cf.Libs.Service.Orders
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IMethodRepository _methodRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMethodRepository methodRepository,
            IPriceRepository priceRepository,
            IItemRepository itemRepository,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository) : base(unitOfWork, mapper)
        {
            _methodRepository = methodRepository;
            _priceRepository = priceRepository;
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }
    }
}
