using Cf.Libs.Core.Enums;

namespace Cf.Libs.Service.Dtos.Item
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Highlights { get; set; }
        public int Order { get; set; }
        public ItemType Type { get; set; }
        public string TypeName => Type.ToString();
        public decimal? Rate { get; set; }
        public byte? Tax { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? Discount { get; set; }
    }
}