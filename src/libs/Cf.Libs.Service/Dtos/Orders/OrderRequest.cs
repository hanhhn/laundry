namespace Cf.Libs.Service.Dtos.Orders
{
    public class OrderRequest
    {
        public int CleanId { get; set; }
        public int[] OptionsId { get; set; }
        public int DeliveryId { get; set; }
        public string Note { get; set; }

        public int AddressId { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int WardId { get; set; }
        public string Street { get; set; }

        public string DateOfReceipt { get; set; }
        public string HoursOfReceipt { get; set; }
    }
}
