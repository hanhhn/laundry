using Cf.Libs.Core.Infrastructure.Entity;
using Cf.Libs.DataAccess.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.DataAccess.Entities.Orders
{
    public class Order : BaseEntity<string>
    {
        public string OrderCode { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int WardId { get; set; }
        public string WardName { get; set; }
        public string Street { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public string HoursOfReceipt { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
