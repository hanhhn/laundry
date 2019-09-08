using System;
using System.Collections.Generic;

namespace Cf.Libs.Service.Dtos.Orders
{
    public class OrderDto
    {
        public string Id { get; set; }
        public string OrderCode { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string WardName { get; set; }
        public string Street { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public string HoursOfReceipt { get; set; }
        public string Method { get; set; }
        public string Soft { get; set; }
        public string Straight { get; set; }
        public string Delivery { get; set; }

        public string FullAddress => string.Format("{0}, {1}, {2}, {3}.", Street, WardName, DistrictName, ProvinceName);
    }
}
