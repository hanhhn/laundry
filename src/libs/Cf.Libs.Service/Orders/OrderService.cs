using AutoMapper;
using Cf.Laundry.Common;
using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Common;
using Cf.Libs.DataAccess.Entities.Orders;
using Cf.Libs.DataAccess.Repository.Addresses;
using Cf.Libs.DataAccess.Repository.Bills;
using Cf.Libs.DataAccess.Repository.Districts;
using Cf.Libs.DataAccess.Repository.Items;
using Cf.Libs.DataAccess.Repository.Methods;
using Cf.Libs.DataAccess.Repository.OrderDetails;
using Cf.Libs.DataAccess.Repository.Orders;
using Cf.Libs.DataAccess.Repository.Prices;
using Cf.Libs.DataAccess.Repository.Provinces;
using Cf.Libs.DataAccess.Repository.Trackings;
using Cf.Libs.DataAccess.Repository.Wards;
using Cf.Libs.Service.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cf.Libs.Service.Orders
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IMethodRepository _methodRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IWardRepository _wardRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ITrackingRepository _trackingRepository;
        private readonly IBillRepository _billRepository;

        public OrderService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMethodRepository methodRepository,
            IPriceRepository priceRepository,
            IItemRepository itemRepository,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IProvinceRepository provinceRepository,
            IDistrictRepository districtRepository,
            IWardRepository wardRepository,
            ITrackingRepository trackingRepository,
            IAddressRepository addressRepository,
            IBillRepository billRepository) : base(unitOfWork, mapper)
        {
            _methodRepository = methodRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _provinceRepository = provinceRepository;
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
            _addressRepository = addressRepository;
            _trackingRepository = trackingRepository;
            _billRepository = billRepository;
        }


        public OrderDto SaveOrder(OrderRequest request)
        {
            var address = _addressRepository.Get(request.AddressId);
            if (address == null)
            {
                var province = _provinceRepository.Get(request.ProvinceId);
                var district = _districtRepository.Get(request.DistrictId);
                var ward = _wardRepository.Get(request.WardId);

                var item = _mapper.Map<Address>(request);
                item.Province = string.Format("{0} {1}", province.Prefix, province.Name).Trim();
                item.District = string.Format("{0} {1}", district.Prefix, district.Name).Trim();
                item.Ward = string.Format("{0} {1}", ward.Prefix, ward.Name).Trim();
                address = _addressRepository.Add(item);
            }

            DateTime dateOfReceipt = DateTime.Now;
            DateTime.TryParse(request.DateOfReceipt, out dateOfReceipt);
            var order = new Order
            {
                OrderCode = Utility.GetDigits(),
                Phone = address.Phone,
                FullName = address.FullName,
                ProvinceId = address.ProvinceId,
                ProvinceName = address.Province,
                DistrictId = address.DistrictId,
                DistrictName = address.District,
                WardId = address.WardId,
                WardName = address.Ward,
                Street = address.Street,
                DateOfReceipt = dateOfReceipt,
                HoursOfReceipt = request.HoursOfReceipt,
                Note = request.Note,
                Address = address
            };

            var orderInserted = _orderRepository.Add(order);

            List<int> methodRequests = new List<int>();
            methodRequests.Add(request.CleanId);
            methodRequests.AddRange(request.OptionsId);
            methodRequests.Add(request.DeliveryId);

            foreach (var methodId in methodRequests)
            {
                var method = _methodRepository.Get(methodId);
                if (method != null)
                {
                    var detail = _orderDetailRepository.Add(new OrderDetail
                    {
                        Order = order,
                        Qty = 0,
                        MethodId = method.Id,
                        MethodName = method.Name,
                        Description = method.Description,
                        Type = method.Type
                    });

                    _orderDetailRepository.Add(detail);
                }
            }

            _trackingRepository.Add(new Tracking
            {
                Phone = request.Phone,
                OrderCode = orderInserted.OrderCode,
                OrderStatus = Core.Enums.OrderStatus.Receive,
            });

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return _mapper.Map<OrderDto>(orderInserted);
        }

        public bool UpdateOrderDetail(OrderDetailRequest request)
        {
            var order = _orderRepository.Get(request.OrderId);
            if (order == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            // delete
            var exists = request.Details.ToList();
            var deleteList = _orderDetailRepository.FindBy(x => x.OrderId == order.Id
                                   && !exists.Any(y => y.MethodId == x.MethodId) 
                                   && x.Type != MethodType.Delivery.ToString()).ToList();

            foreach(var item in deleteList)
            {
                _orderDetailRepository.Remove(item);
            }

            foreach (var detail in request.Details)
            {
                var orderDetail = _orderDetailRepository.FindBy(x => x.OrderId == order.Id
                                    && x.MethodId == detail.MethodId).SingleOrDefault();

                if (orderDetail == null)
                {
                    var method = _methodRepository.Get(detail.MethodId);
                    _orderDetailRepository.Add(new OrderDetail
                    {
                        Order = order,
                        Qty = detail.Qty,
                        MethodId = method.Id,
                        MethodName = method.Name,
                        Description = method.Description,
                        Type = method.Type
                    });
                }
                else
                {
                    orderDetail.Qty = detail.Qty;
                    _orderDetailRepository.Update(orderDetail);
                }
            }

            return _unitOfWork.SaveChanges() > 0;
        }

        public IPagedList<OrderDto> Get(OrderFilter filter)
        {
            var queryOrders = from o in _orderRepository.GetQuery()
                              where !o.IsDeleted
                              select o;

            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                queryOrders = from o in queryOrders
                              where o.Phone == filter.Keyword
                                || o.OrderCode == filter.Keyword
                                || o.FullName.Contains(filter.Keyword)
                              select o;
            }

            queryOrders = from o in queryOrders
                          orderby o.CreateDate descending
                          select o;

            var result = queryOrders.ToPagedList<Order, OrderDto>(filter.PageIndex, filter.PageSize);

            return result;
        }

        public OrderDto Get(string id)
        {
            var queryOrders = from o in _orderRepository.GetQuery()
                              where !o.IsDeleted && o.Id == id
                              select o;

            var record = queryOrders.SingleOrDefault();
            if (record == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            var order = _mapper.Map<OrderDto>(record);
            var bill = _billRepository.GetBill(record.Phone, record.OrderCode);
            if (bill != null)
            {
                order.BillId = bill.Id;
            }

            return order;
        }
    }
}