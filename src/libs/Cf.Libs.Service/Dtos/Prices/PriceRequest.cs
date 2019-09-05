using System;

namespace Cf.Libs.Service.Dtos.Prices
{
    public class PriceRequest
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public decimal Rate { get; set; }
        public byte Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountRate { get; set; }
        public byte Priority { get; set; }
        public bool IsActive { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}