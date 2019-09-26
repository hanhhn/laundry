using Cf.Libs.Core.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.DataAccess.Entities.Billing
{
    public class BillDetail : BaseEntity<int>
    {
        [ForeignKey("Bill")]
        public int BillId { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
