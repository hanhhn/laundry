namespace Cf.Libs.Service.Dtos.Setting
{
    public class CompanyInfoDto : SettingDto
    {
        public string Brand { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string GoogleMap { get; set; }
        public string Copyright { get; set; }
    }
}