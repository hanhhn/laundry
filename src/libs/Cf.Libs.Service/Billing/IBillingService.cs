using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Billing;

namespace Cf.Libs.Service.Billing
{
    public interface IBillingService : IBaseService
    {
        BillDto Get(int id);
        BillDto Publish(string orderId);
        bool UnPublish(string orderId);
    }
}