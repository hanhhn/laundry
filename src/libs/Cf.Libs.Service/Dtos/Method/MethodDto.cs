using Cf.Libs.Core.Enums;

namespace Cf.Libs.Service.Dtos.Method
{
    public class MethodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public bool EnableDiscount { get; set; }
        public MethodType Type { get; set; }
    }
}