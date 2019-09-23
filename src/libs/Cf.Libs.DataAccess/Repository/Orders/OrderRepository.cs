using System.Linq;
using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace Cf.Libs.DataAccess.Repository.Orders
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override IQueryable<Order> GetQuery()
        {
            return base.GetQuery().Include(x => x.Address).Include(x => x.OrderDetails);
        }
    }
}