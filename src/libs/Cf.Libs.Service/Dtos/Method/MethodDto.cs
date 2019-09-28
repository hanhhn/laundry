namespace Cf.Libs.Service.Dtos.Method
{
    public class MethodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int SortOrder { get; set; }
        public decimal Rate { get; set; }
        public byte Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountRate { get; set; }
        public bool EnableDiscount { get; set; }
        public string Unit { get; set; }
        public string FullName => string.Format("{0} - {1}", Type, Name);
    }
}