using Cf.Libs.Core.Infrastructure.DataAccess;
using Cf.Libs.DataAccess.DbContext;
using Cf.Libs.DataAccess.Entities.Orders;

namespace Cf.Libs.DataAccess.Repository.Orders
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}