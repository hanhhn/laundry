using AutoMapper;
using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Core.Infrastructure.UnitOfWork;
using Cf.Libs.DataAccess.Repository.Methods;
using Cf.Libs.DataAccess.Repository.Prices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Service.OrderDetails
{
    public class OrderDetailService : BaseService, IOrderDetailService
    {
        private readonly IMethodRepository _methodRepository;
        private readonly IPriceRepository _priceRepository;

        public OrderDetailService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMethodRepository methodRepository,
            IPriceRepository priceRepository) : base(unitOfWork, mapper)
        {
            _methodRepository = methodRepository;
            _priceRepository = priceRepository;
        }
    }
}
