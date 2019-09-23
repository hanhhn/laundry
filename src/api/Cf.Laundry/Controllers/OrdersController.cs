﻿using Cf.Libs.Core.Infrastructure.Paging;
using Cf.Libs.Service.Dtos.Order;
using Cf.Libs.Service.Orders;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cf.Laundry.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("save")]
        public OrderDto SaveOrder(OrderRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            return _orderService.SaveOrder(request);
        }

        [HttpGet]
        [Route("get")]
        public IPagedList<OrderDto> GetOrders([FromQuery] OrderFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("Param is invalid.");
            }

            return _orderService.Get(filter);
        }
    }
}