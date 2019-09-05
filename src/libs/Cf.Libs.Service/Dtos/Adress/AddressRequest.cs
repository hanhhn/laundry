namespace Cf.Libs.Service.Dtos.Adress
{
    public class AddressRequest
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public bool IsDefault { get; set; }
        public int ProviceId { get; set; }
        public string Provice { get; set; }
        public int DistrictId { get; set; }
        public string District { get; set; }
        public int WardId { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
    }
}