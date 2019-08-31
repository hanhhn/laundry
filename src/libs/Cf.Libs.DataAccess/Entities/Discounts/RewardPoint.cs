using Cf.Libs.Core.Infrastructure.Entity;

namespace Cf.Libs.DataAccess.Entities.Discounts
{
    public class RewardPoint : BaseEntity<int>
    {
        public string Phone { get; set; }
        public decimal Point { get; set; }
    }
}