using Cf.Libs.Service.Dto.Item;
using System;

namespace Cf.Libs.Service.Dto.ItemRate
{
    public class ItemRateDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal Rate { get; set; }
        public byte Tax { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal Discount { get; set; }
        public byte Priority { get; set; }
        public bool IsActive { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public ItemDto Item { get; set; }
    }
}