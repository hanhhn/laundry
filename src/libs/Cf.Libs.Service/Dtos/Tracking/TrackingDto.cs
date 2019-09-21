using Cf.Libs.Core.Enums;

namespace Cf.Libs.Service.Dtos.Tracking
{
    public class TrackingDto
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Status => OrderStatus.ToString();
    }
}
