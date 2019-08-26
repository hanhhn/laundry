using Cf.Libs.Core.Infrastructure.Entity;

namespace Cf.Libs.DataAccess.Entities.Common
{
    public class Address : BaseEntity<int>
    {
        public string Phone { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Wards { get; set; }
        public string Street { get; set; }
    }
}