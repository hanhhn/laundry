using Cf.Libs.Core.Enums;

namespace Cf.Libs.Service.Dtos.Method
{
    public class MethodRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool EnableDiscount { get; set; }
        public string Type { get; set; }
    }
}