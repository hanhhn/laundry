using Cf.Libs.Service.Dtos.Item;
using System;

namespace Cf.Libs.Service.Dtos.ItemRate
{
    public class ItemRateDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Rate { get; set; }
        public byte Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountRate { get; set; }
        public byte Priority { get; set; }
        public bool IsActive { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime ExpireDate { get; set; } = DateTime.Now;
        public ItemDto Item { get; set; }
    }
}