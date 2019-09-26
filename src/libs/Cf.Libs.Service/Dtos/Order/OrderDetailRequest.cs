namespace Cf.Libs.Service.Dtos.Order
{
    public class OrderDetailRequest
    {
        public string OrderId { get; set; }
        public Detail[] Details { get; set; }
    }

    public class Detail
    {
        public int Id { get; set; }
        public float Qty { get; set; }
    }
}