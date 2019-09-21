using AutoMapper;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Orders;
using Cf.Libs.DataAccess.Repository.OrderDetails;
using Cf.Libs.DataAccess.Repository.Orders;
using Cf.Libs.DataAccess.Repository.Trackings;
using Cf.Libs.Service.Dtos.Method;
using Cf.Libs.Service.Dtos.Tracking;
using System.Collections.Generic;
using System.Linq;

namespace Cf.Libs.Service.Trackings
{
    public class TrackingService : BaseService, ITrackingService
    {
        private readonly ITrackingRepository _trackingRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public TrackingService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ITrackingRepository trackingRepository,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository) : base(unitOfWork, mapper)
        {
            _trackingRepository = trackingRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public OrderHistoryDto Order(string phone, string orderCode)
        {
            var order = (from o in _orderRepository.GetQuery()
                         where o.OrderCode == orderCode && o.Phone == phone
                         select o).SingleOrDefault();

            if (order == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            var orderDetail = (from d in _orderDetailRepository.GetQuery()
                               where d.OrderId == order.Id
                               select d).ToList();

            var tracking = (from track in _trackingRepository.GetQuery()
                            where track.OrderCode == order.OrderCode && track.Phone == order.Phone
                            orderby track.CreateDate descending
                            orderby track.ModifiedDate descending
                            select track).AsEnumerable();

            OrderHistoryDto history = new OrderHistoryDto
            {
                OrderCode = order.OrderCode,
                OrderStatus = _mapper.Map<IEnumerable<TrackingDto>>(tracking),
                PaymentStatus = order.Status,
                PurchaseDate = order.CreateDate,
                DateOfReceipt = order.DateOfReceipt,
                HoursOfReceipt = order.HoursOfReceipt,
                FullAddress = string.Format("{0}, {1}, {2}, {3}.", order.Street, order.WardName, order.DistrictName, order.ProvinceName),
                Amount = 0,
                Services = _mapper.Map<IEnumerable<MethodDto>>(orderDetail)
            };

            return history;
        }
    }
}
