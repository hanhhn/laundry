using AutoMapper;
using Cf.Laundry.Common;
using Cf.Libs.Core.Exeptions;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Entities.Billing;
using Cf.Libs.DataAccess.Repository.Addresses;
using Cf.Libs.DataAccess.Repository.BillDetails;
using Cf.Libs.DataAccess.Repository.Bills;
using Cf.Libs.DataAccess.Repository.OrderDetails;
using Cf.Libs.DataAccess.Repository.Orders;
using Cf.Libs.DataAccess.Repository.Prices;
using Cf.Libs.DataAccess.Repository.Trackings;
using Cf.Libs.Service.Dtos.Billing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cf.Libs.Service.Billing
{
    public class BillingService : BaseService, IBillingService
    {
        private readonly IBillRepository _billRepository;
        private readonly IBillDetailRepository _billDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ITrackingRepository _trackingRepository;
        private readonly IPriceRepository _priceRepository;

        public BillingService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IBillRepository billRepository,
            IBillDetailRepository billDetailRepository,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IAddressRepository addressRepository,
            ITrackingRepository trackingRepository,
            IPriceRepository priceRepository) : base(unitOfWork, mapper)
        {
            _billRepository = billRepository;
            _billDetailRepository = billDetailRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _addressRepository = addressRepository;
            _trackingRepository = trackingRepository;
            _priceRepository = priceRepository;
        }

        public BillDto Get(int id)
        {
            var query = from b in _billRepository.GetQuery()
                        where !b.IsDeleted && b.Id == id
                        select b;
            return _mapper.Map<BillDto>(query.SingleOrDefault());
        }

        public BillDto Publish(string orderId)
        {
            var order = _orderRepository.Get(orderId);
            if (order == null)
            {
                throw new RecordNotFoundException("Record can not be found.");
            }

            var bill = _billRepository.FindBy(x => x.Phone == order.Phone && x.OrderCode == order.OrderCode).SingleOrDefault();
            if(bill != null)
            {
                throw new InformationException("Bill is published!");
            }

            bill = _billRepository.Add(new Bill
            {
                BillCode = Utility.GetDigits(8),
                OrderCode = order.OrderCode,
                Phone = order.Phone,
                FullName = order.FullName,
                Address = string.Format("{0}, {1}, {2}, {3}.", order.Street, order.WardName, order.DistrictName, order.ProvinceName),
                Discount = 0,
            });

            var services = _orderDetailRepository.FindBy(x => x.OrderId == order.Id);
            List<BillDetail> billDetail = new List<BillDetail>();
            foreach (var item in services)
            {
                var rate = _priceRepository.GetRate(item.MethodId);

                if (rate == null || rate.Rate == 0)
                {
                    throw new InformationException("Rate can not be found!");
                }

                var detail = _billDetailRepository.Add(new BillDetail
                {
                    Description = item.MethodName,
                    Qty = 1,
                    Rate = rate.Rate,
                    Amount = rate.Rate * 1,
                    Bill = bill,
                });

                billDetail.Add(detail);
            }

            bill.Amount = billDetail.Sum(x => x.Amount);
            bill.BillAmount = bill.Amount * (1 - bill.Discount / 100);

            if (_unitOfWork.SaveChanges() == 0)
            {
                throw new InformationException("An error occurred during save.");
            }

            return _mapper.Map<BillDto>(bill);
        }

        public bool UnPublish(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}