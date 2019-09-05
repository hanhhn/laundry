using Cf.Libs.Core.Infrastructure.Entity;

namespace Cf.Libs.DataAccess.Entities.Common
{
    public class Address : BaseEntity<int>
    {
        public string Phone { get; set; }
        public string FullName { get; set; }
        public bool IsDefault { get; set; }
        public int ProvinceId { get; set; }
        public string Province { get; set; }
        public int DistrictId { get; set; }
        public string District { get; set; }
        public int WardId { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
    }
}