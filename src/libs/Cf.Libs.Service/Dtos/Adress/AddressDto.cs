namespace Cf.Libs.Service.Dtos.Adress
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public int ProvinceId { get; set; }
        public string Province { get; set; }
        public int DistrictId { get; set; }
        public string District { get; set; }
        public int WardId { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
        public bool IsDefault { get; set; }
        public string FullAddress => string.Format("Địa chỉ: {0}, {1}, {2}, {3}.", Street, Ward, District, Province);
    }
}