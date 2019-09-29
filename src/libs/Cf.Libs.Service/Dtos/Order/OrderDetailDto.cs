namespace Cf.Libs.Service.Dtos.Order
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int MethodId { get; set; }
        public string MethodName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public float Qty { get; set; }
    }
}