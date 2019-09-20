using Cf.Libs.Core.Infrastructure.Service;
using Cf.Libs.Service.Dtos.Tracking;

namespace Cf.Libs.Service.Trackings
{
    public interface ITrackingService : IBaseService
    {
        OrderHistoryDto Order(string phone, string orderCode);
    }
}
