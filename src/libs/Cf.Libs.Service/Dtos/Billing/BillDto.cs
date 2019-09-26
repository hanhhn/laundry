using System;
using System.Collections.Generic;

namespace Cf.Libs.Service.Dtos.Billing
{
    public class BillDto
    {
        public int Id { get; set; }
        public string BillCode { get; set; }
        public string OrderCode { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Coupon { get; set; }
        public int Discount { get; set; }
        public decimal Amount { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime CreateDate { get; set; }

        public IEnumerable<BillDetailDto> BillDetails { get; set; }
    }
}