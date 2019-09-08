using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Orders;

namespace Cf.Libs.Service.Orders
{
    public interface IOrderService : IBaseService
    {
        OrderDto SaveOrder(OrderRequest request);
    }
}
