using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Entity;

namespace Cf.Libs.DataAccess.Entities.Orders
{
    public class Tracking : BaseEntity<int>
    {
        public string Phone { get; set; }
        public string OrdeCode { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
