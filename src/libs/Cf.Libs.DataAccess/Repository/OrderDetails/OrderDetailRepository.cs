using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.DataAccess.Repository.OrderDetails
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}