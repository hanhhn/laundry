namespace Cf.Libs.Service.Dtos.Item
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Highlight { get; set; }
        public int SortOrder { get; set; }
        public string Type { get; set; }
        public decimal Rate { get; set; }
        public byte Tax { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal Discount { get; set; }
    }
}