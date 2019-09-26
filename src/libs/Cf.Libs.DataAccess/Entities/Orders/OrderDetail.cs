using Cf.Libs.Core.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.DataAccess.Entities.Orders
{
    public class OrderDetail : BaseEntity<int>
    {
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public float Qty { get; set; }
        public int MethodId { get; set; }
        public string MethodName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public virtual Order Order { get; set; }
    }
}